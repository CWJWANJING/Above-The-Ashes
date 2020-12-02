using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1switchB : MonoBehaviour
{
    public GameObject UIObject;
    public GameObject player;
    public static bool door2open;
    public static bool door3open;
	public GameObject Door2;
	public GameObject Door3;
	
	private Vector3 offset = new Vector3 (0.0f, 1.0f,0.0f);
	public static bool trigger2;
	private int num = 0;
	
    void Start()
    {
        // at first the text should not display
        UIObject.SetActive(false);
		trigger2 = false;
    }

    void OnTriggerEnter(Collider other)
    {
        // when player is near the chest
        if (other.tag == "Player")
        {
            // show the text
            UIObject.SetActive(true);
        }
    }


	void Update()
    {
       if (Vector3.Distance(this.gameObject.transform.position, player.transform.position) < 1.5){
			if(Input.GetKey("f")){
				//print(trigger);
				trigger2 = true;
				num = 0;
				//print("B");
			}
	   }
	   
    }

	void LateUpdate()
    {
      // if player is closenough with this object
		if (Vector3.Distance(this.gameObject.transform.position, player.transform.position) < 1.5)
		{
			UIObject.SetActive(true);

			//if (Input.GetKey("f"))
			//{
			//	door2open = true;
			//	door3open = false;
			//}
			
			if (trigger2)
			{
				if(Door3.transform.localEulerAngles.y>=90&&Door3.transform.localEulerAngles.y<=180f){
					Door3.transform.localEulerAngles = Door3.transform.localEulerAngles - offset;
				}
				if(Door2.transform.localEulerAngles.y>=90&&Door2.transform.localEulerAngles.y<=180f){
					Door2.transform.localEulerAngles = Door2.transform.localEulerAngles + offset;
				}
				num++;
				//door3open = true;
				if (num >90){
					trigger2 = false;
				}
			}
			
        }
		else{
			UIObject.SetActive(false);
		}
		
    }

}
