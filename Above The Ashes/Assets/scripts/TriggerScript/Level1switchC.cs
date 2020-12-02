using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1switchC : MonoBehaviour
{
    public GameObject UIObject;
	public GameObject player;
    public static bool door1open;
    public static bool door2open;
    public static bool door3open;
    public static bool door4open;
	public GameObject Door1;
	public GameObject Door2;
	public GameObject Door3;
	public GameObject Door4;
	private Vector3 offset = new Vector3 (0.0f, 1.0f,0.0f);
	private bool trigger3;
	private int num = 0;
	

    void Start()
    {
        // at first the text should not display
        UIObject.SetActive(false);
		trigger3 = false;
		//print("C");
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

    void OnTriggerExit(Collider other)
    {
        // when player leaves the trigger, text disappear
        UIObject.SetActive(false);
    }



	void Update()
    {
       if (Vector3.Distance(this.gameObject.transform.position, player.transform.position) < 1.5){
			if(Input.GetKey("f")){
				//print(trigger);
				trigger3 = true;
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
        //door1open = true;
				//door2open = false;
        //door3open = false;
        //door4open = false;
			//}
			if (trigger3)
			{
				if(Door1.transform.localEulerAngles.y>=90&&Door1.transform.localEulerAngles.y<=180f){
					Door1.transform.localEulerAngles = Door1.transform.localEulerAngles + offset;
				}
				if(Door2.transform.localEulerAngles.y>=90&&Door2.transform.localEulerAngles.y<=180f){
					Door2.transform.localEulerAngles = Door2.transform.localEulerAngles - offset;
				}
				if(Door3.transform.localEulerAngles.y>=90&&Door3.transform.localEulerAngles.y<=180f){
					Door3.transform.localEulerAngles = Door3.transform.localEulerAngles - offset;
				}
				if(Door4.transform.localEulerAngles.y>=90&&Door3.transform.localEulerAngles.y<=180f){
					Door4.transform.localEulerAngles = Door3.transform.localEulerAngles - offset;
				}				
				num++;
				if (num >=90){
					trigger3 = false;
				}
			}
        }
		else{
			UIObject.SetActive(false);
		}
		
    }
}
