using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TPSCamera : MonoBehaviour
{
    public static TPSCamera _instance;//用作单例模式
    public Camera cam;//摄像机，是本物体下的子物体
    public Transform player;//玩家物体的Transform
    public Vector3 playerOffset;//本物体与玩家位置的偏移向量
    public GameObject pistol;

    public float rotateSpeed;//控制旋转速度
    public float moveSpeed;//控制跟随的平滑度

    public float minAngle;//垂直视角的最小角度值
    public float maxAngle;//垂直视角的最大角度值

    public float localOffsetSpeed = 8;//控制相机与父物体偏移时的平滑度
    public float localOffsetAim = 2;//根据是否瞄准而产生的偏移量，表示瞄准时摄像机应该前进多远距离，根据需要设值
    private float localOffsetAngle = 0;//根据垂直视角角度而产生的偏移量
    public float localOffsetAngleUp = 1.5f;//根据向上的角度而产生的偏移量的最大值
    public float localOffsetAngleDown = 1.5f;//根据向下的角度而产生的偏移量的最大值
    private float localOffsetCollider = 0;//根据玩家与摄像机间是否有遮挡而产生的偏移量

    private Animator animator;
    private bool isSprint;

    public bool isAiming = false;//是否正在瞄准

    private void Awake()
    {
        _instance = this;
        player = GameObject.Find("Player").transform;//根据名字找到玩家物体
        playerOffset = player.position - transform.position;//初始化playerOffset
        cam = transform.GetComponentInChildren<Camera>();//获取子物体的Camera组件
    }

    private void Update()
    {
        animator = player.gameObject.GetComponent<Animator>();
        isSprint = animator.GetBool("IsSprinting");
        if (isSprint)
        {
            isAiming = false;
            pistol.SetActive(false);

        }
        if (Input.GetMouseButtonDown(1) && !isSprint)//鼠标右键按下为瞄准
        {
           isAiming = !isAiming;
           pistol.SetActive(isAiming);
        }
        //if (Input.GetMouseButtonDown(1) && !isSprint)//鼠标右键按下为瞄准
        //{
        //   isAiming = true;
        //   pistol.SetActive(true);
        //}
        //if (Input.GetMouseButtonUp(1))//鼠标右键松开停止瞄准
        //{
        //  isAiming = false;
        //   pistol.SetActive(false);

        //}
        SetPosAndRot();//设置视角旋转后的位置和朝向
        Cursor.visible = false;//隐藏鼠标
    }

    /// <summary>
    /// 上下移动鼠标时，相机围绕玩家旋转，并且限制旋转角度
    /// </summary>
    public void SetPosAndRot()
    {
        //更新本物体的position,相机会和本物体做相同的位移，使相机平滑跟随玩家
        transform.position = Vector3.Lerp(transform.position, player.position - playerOffset, moveSpeed * Time.deltaTime);

        //获取鼠标移动量
        float axisX = Input.GetAxis("Mouse X") * rotateSpeed * Time.deltaTime;
        float axisY = Input.GetAxis("Mouse Y") * rotateSpeed * Time.deltaTime;

        //计算水平和垂直的旋转角
        Quaternion rotX = Quaternion.AngleAxis(axisX, Vector3.up);
        Quaternion rotY = Quaternion.AngleAxis(-axisY, transform.right);

        //摄像机在水平方向绕玩家旋转
        transform.RotateAround(player.position, Vector3.up, axisX);

        //保存未旋转垂直视角前的position和rotation
        Vector3 posPre = transform.position;
        Quaternion rotPre = transform.rotation;

        //先垂直绕玩家旋转，注意这里旋转的轴为transform.right
        transform.RotateAround(player.position, transform.right, -axisY);

        //判断垂直角度是否符合范围
        float x = (transform.rotation).eulerAngles.x;
        //欧拉角范围为0~360，这里要转为-180~180方便判断
        if (x > 180) x -= 360;
        if (x < minAngle || x > maxAngle)//超出角度
        {
            //还原位置和旋转
            transform.position = posPre;
            transform.rotation = rotPre;

            //更新offset向量,offset与本物体同步旋转
            //我们需要通过这offset去计算本物体（包括摄像机）应该平滑移向的位置
            //如果仅仅使用RotateAround函数，当人物在移动时会出现误差
            playerOffset = rotX * playerOffset;
        }
        else//垂直视角符合范围的情况
        {
            //更新offset向量,offset与本物体同步旋转
            playerOffset = rotX * rotY * playerOffset;

            //更据角度设置摄像机位置偏移
            if (x < 0)//往上角度为负
            {
                //往上看时距离拉近
                localOffsetAngle = (x / minAngle) * localOffsetAngleUp;
            }
            else
            {
                //往下看时距离拉远
                localOffsetAngle = -(x / maxAngle) * localOffsetAngleDown;
            }
        }

        //设置摄像机与父物体的偏移，三个影响因素
        SetLocalOffset();
    }

    /// <summary>
    /// 根据是否瞄准、垂直视角和是否有遮挡来调整摄像机与父物体的偏移
    /// </summary>
    public void SetLocalOffset()
    {
        float localOffset = 0;//摄像机与父物体（即本脚本所在的空物体）的偏移
        //根据垂直视角调整
        localOffset += localOffsetAngle;
        //根据是否瞄准而调整
        if (isAiming)
        {
            localOffset += localOffsetAim;
        }

        //根据是否有遮挡而调整
        Vector3 checkPos = transform.position + cam.transform.forward * localOffset;//这是没有调整前相机应该移向的位置
        for (localOffsetCollider = 0; !CheckView(checkPos); localOffsetCollider += 0.2f)//让localOffset递增直至没有遮挡
        {
            //更新checkPos为我们想要移动到的位置，再去试探
            checkPos = transform.position + cam.transform.forward * (localOffset + localOffsetCollider);
        }
        localOffset += localOffsetCollider;//加上这个试探出的偏移量

        Vector3 offsetPos = new Vector3(0, 0, localOffset);//这是调整后相机应该移向的位置
        //使相机平滑移动到这个位置
        cam.transform.localPosition = Vector3.Lerp(cam.transform.localPosition, offsetPos, localOffsetSpeed * Time.deltaTime);
    }

    /// <summary>
    /// 检查玩家与摄像机之间是否有碰撞体遮挡
    /// </summary>
    /// <param name="checkPos">假设相机的位置</param>
    /// <returns></returns>
    private bool CheckView(Vector3 checkPos)
    {
        //发出射线来检测碰撞
        RaycastHit hit;
        //射线终点为玩家物体的中间位置
        Vector3 endPos = player.position + player.up * player.GetComponent<CapsuleCollider>().height * 0.5f;

        Debug.DrawLine(checkPos, endPos, Color.blue);

        //从checkPos发射一条长度为起点到终点距离的射线
        if (Physics.Raycast(checkPos, endPos - checkPos, out hit, (endPos - checkPos).magnitude))
        {
            if (hit.transform == player)//如果射线打到玩家说明没有遮挡
                return true;
            else//如果射线打击到其他物体说明有遮挡
                return false;
        }
        return true;//如果射线没有打到任何物体也说明没有遮挡
    }

}
