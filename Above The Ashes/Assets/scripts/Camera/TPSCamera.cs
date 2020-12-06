using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TPSCamera : MonoBehaviour
{
    public static TPSCamera _instance;//Used as a singleton pattern
    public Camera cam;//The camera is a sub-object under this object
    public Transform player;//Transform of the player object
    public Vector3 playerOffset;//The offset vector of this object and the player's position
    public GameObject puzzle;

    public float rotateSpeed;//Control rotation speed (Sensitive)
    public float moveSpeed;//Control the smoothness of following

    public float minAngle;//Minimum angle of vertical viewing angle
    public float maxAngle;//Maximum angle of vertical viewing angle

    public float localOffsetSpeed = 8;//Control the smoothness when the camera is offset from the parent object
    public float localOffsetAim = 2;//The offset according to whether or not to aim, 
    //indicates how far the camera should advance when aiming, and set the value as required

    private float localOffsetAngle = 0;//Offset due to vertical viewing angle
    public float localOffsetAngleUp = 1.5f;//The maximum value of the offset according to the upward angle
    public float localOffsetAngleDown = 1.5f;//The maximum value of the offset according to the downward angle
    private float localOffsetCollider = 0;//Offset based on whether there is occlusion between the player and the camera

    private Animator animator;
    private bool isSprint;

    public bool isAiming = false;//Is aiming or not

    private void Awake()
    {
        _instance = this;
        player = GameObject.Find("Player").transform;//Find the player object by name
        playerOffset = player.position - transform.position;//Initialize playerOffset
        cam = transform.GetComponentInChildren<Camera>();//Get the Camera component of the child object
    }

    private void Update()
    {
        animator = player.gameObject.GetComponent<Animator>();// Get animator
        isSprint = animator.GetBool("IsSprinting");// Set param isSprint
        puzzle = GameObject.FindGameObjectWithTag("Puzzle");
        if (isSprint)
        {
            isAiming = false;

        }
        if (Input.GetMouseButtonDown(1) && !isSprint)//Press the right mouse button to aim
        {
           isAiming = !isAiming;
        }
        //if (Input.GetMouseButtonDown(1) && !isSprint)//Press the right mouse button to aim (Hold)
        //{
        //   isAiming = true;
        //   pistol.SetActive(true);
        //}
        //if (Input.GetMouseButtonUp(1))//Release the right mouse button to stop aiming
        //{
        //  isAiming = false;
        //   pistol.SetActive(false);

        //}
        SetPosAndRot();//Set the position and orientation of the viewing angle after rotation

        if (puzzle.GetComponent<showPuzzleWeapon>().playPuzzle)// Set cursor visual
        {
            Cursor.visible = true;//Display
        }
        else if (player.GetComponent<PlayerSystem>().gamePause) {
            Cursor.visible = true;//Display
        }
        else if (finalscript.eogmenuTrigger == true) {
            Cursor.visible = true;//Display
        }
        else
        {
            Cursor.visible = false;//hide
        }
    }

    /// <summary>
    /// When moving the mouse up and down, the camera rotates around the player, and the rotation angle is limited
    /// </summary>
    public void SetPosAndRot()
    {
        //Update the position of the object, the camera will make the same displacement as the object, making the camera follow the player smoothly
        transform.position = Vector3.Lerp(transform.position, player.position - playerOffset, moveSpeed * Time.deltaTime);

        //Get mouse movement
        float axisX = Input.GetAxis("Mouse X") * rotateSpeed * Time.deltaTime;
        float axisY = Input.GetAxis("Mouse Y") * rotateSpeed * Time.deltaTime;

        //Calculate the horizontal and vertical rotation angle
        Quaternion rotX = Quaternion.AngleAxis(axisX, Vector3.up);
        Quaternion rotY = Quaternion.AngleAxis(-axisY, transform.right);

        //The camera rotates around the player in the horizontal direction
        transform.RotateAround(player.position, Vector3.up, axisX);

        //Save the position and rotation before the unrotated vertical viewing angle
        Vector3 posPre = transform.position;
        Quaternion rotPre = transform.rotation;

        //Rotate vertically around the player first, note that the axis of rotation here is transform.right
        transform.RotateAround(player.position, transform.right, -axisY);

        //Determine whether the vertical angle meets the range
        float x = (transform.rotation).eulerAngles.x;
        //The range of Euler angle is 0~360, here it should be changed to -180~180 to facilitate judgment
        if (x > 180) x -= 360;
        if (x < minAngle || x > maxAngle)//Beyond angle
        {
            //Restore position and rotation
            transform.position = posPre;
            transform.rotation = rotPre;

            //Update the offset vector, the offset rotates synchronously with the object
            //We need to use this offset to calculate the position where the object (including the camera) should move smoothly
            //If you only use the RotateAround function, there will be errors when the character is moving
            playerOffset = rotX * playerOffset;
        }
        else//When the vertical viewing angle meets the range
        {
            //Update the offset vector, the offset rotates synchronously with the object
            playerOffset = rotX * rotY * playerOffset;

            //Set the camera position offset according to the angle
            if (x < 0)//Upward angle is negative
            {
                //Get closer when looking up
                localOffsetAngle = (x / minAngle) * localOffsetAngleUp;
            }
            else
            {
                //Zoom out when looking down
                localOffsetAngle = -(x / maxAngle) * localOffsetAngleDown;
            }
        }

        //Set the offset between the camera and the parent object, three influencing factors
        SetLocalOffset();
    }

    /// <summary>
    /// Adjust the offset between the camera and the parent object according to whether it is aimed, vertical angle of view and whether there is occlusion
    /// </summary>
    public void SetLocalOffset()
    {
        float localOffset = 0;//The offset between the camera and the parent object (the empty object where the script is located)
        //Adjust according to vertical viewing angle
        localOffset += localOffsetAngle;
        //Adjust according to whether to aim
        if (isAiming)
        {
            localOffset += localOffsetAim;
        }

        //Adjust according to whether there is occlusion
        Vector3 checkPos = transform.position + cam.transform.forward * localOffset;//This is where the camera should be moved before adjustment
        for (localOffsetCollider = 0; !CheckView(checkPos); localOffsetCollider += 0.2f)//Let localOffset increase until there is no occlusion
        {
            //Update checkPos to the position we want to move to, and try again
            checkPos = transform.position + cam.transform.forward * (localOffset + localOffsetCollider);
        }
        localOffset += localOffsetCollider;//Plus this probed offset

        Vector3 offsetPos = new Vector3(0, 0, localOffset);//This is where the camera should move to after adjustment
        //Make the camera move smoothly to this position
        cam.transform.localPosition = Vector3.Lerp(cam.transform.localPosition, offsetPos, localOffsetSpeed * Time.deltaTime);
    }

    /// <summary>
    /// Check if there is a collision between the player and the camera to block
    /// </summary>
    /// <param name="checkPos">Assuming the location of the camera</param>
    /// <returns></returns>
    private bool CheckView(Vector3 checkPos)
    {
        //Emit rays to detect collisions
        RaycastHit hit;
        //The end of the ray is the middle position of the player's object
        Vector3 endPos = player.position + player.up * player.GetComponent<CapsuleCollider>().height * 0.5f;

        Debug.DrawLine(checkPos, endPos, Color.blue);

        //Launch a ray from checkPos that is the distance from the start point to the end point
        if (Physics.Raycast(checkPos, endPos - checkPos, out hit, (endPos - checkPos).magnitude))
        {
            if (hit.transform == player)//If the ray hits the player, it is not blocked
                return true;
            else//If the ray hits other objects, it is blocked
                return false;
        }
        return true;//If the ray does not hit anything, it means there is no occlusion
    }

}
