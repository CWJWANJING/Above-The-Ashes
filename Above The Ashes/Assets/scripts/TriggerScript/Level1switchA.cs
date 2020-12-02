using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1switchA : MonoBehaviour
{
    public GameObject UIObject;
    public GameObject Door3;
	public GameObject player;
    public static bool door3open;
	private Vector3 offset = new Vector3 (0.0f, 1.0f,0.0f);
	public static bool trigger1;
	private int num = 0;
	
    void Start()
    {
        // at first the text should not display
        UIObject.SetActive(false);
		trigger1 = false;
		
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
				trigger1 = true;
				num = 0;
				//print("A");
			}

				//door3open = true;

		}else{
        UIObject.SetActive(false);
		}
		if (num >=90){
		    trigger1 = false;
		}

		if(trigger1)
		{
		    Action();
		    num++;
		}
    }


	void Action(){

		if(Door3.transform.localEulerAngles.y>=90&&Door3.transform.localEulerAngles.y<=180f){
			Door3.transform.localEulerAngles = Door3.transform.localEulerAngles + offset;
		}

    }

		

}
