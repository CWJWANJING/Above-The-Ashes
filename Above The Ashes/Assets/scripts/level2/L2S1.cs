using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L2S1 : MonoBehaviour
{
    public GameObject UIObject;
    public GameObject Door1;
	public GameObject Door2;
	public GameObject player;
	private Vector3 offset = new Vector3 (0.0f, 1.0f,0.0f);
	private bool trigger;
	private double shootTimer = 0;
    private double shootTimeInterval = 0.1;
	
	
    void Start()
    {
        // at first the text should not display
        UIObject.SetActive(false);
		trigger = false;
		
    }


    void Update()
    {
       if (Vector3.Distance(this.gameObject.transform.position, player.transform.position) < 1.5){
			UIObject.SetActive(true);
			
				
			
			
			if(Input.GetKey("f")){
				//print(trigger);
				shootTimer += Time.deltaTime;
				if (shootTimer > shootTimeInterval) {
					if(trigger){
					trigger = false;
				}
				else{
					trigger = true;
				}
					shootTimer = 0;
				}
				
				
				
			}

				//door3open = true;

		}else{
        UIObject.SetActive(false);
		}
		if(trigger)
		{
		    //print(trigger);
			ActionA();
		}
		else{
			//print(trigger);
			ActionB();
		}
    }


	void ActionA(){

		if(Door1.transform.localEulerAngles.y >= 90f&&Door1.transform.localEulerAngles.y < 180f){
			Door1.transform.localEulerAngles = Door1.transform.localEulerAngles + offset;
		}
		
		if(Door2.transform.localEulerAngles.y >= 0f&&Door2.transform.localEulerAngles.y < 90f){
			Door2.transform.localEulerAngles = Door2.transform.localEulerAngles + offset;
		}
    }
    
	void ActionB(){

		if(Door1.transform.localEulerAngles.y <= 181f&&Door1.transform.localEulerAngles.y > 91f){
			Door1.transform.localEulerAngles = Door1.transform.localEulerAngles - offset;
		}
		if(Door2.transform.localEulerAngles.y >= 1f&&Door2.transform.localEulerAngles.y < 91f){
			Door2.transform.localEulerAngles = Door2.transform.localEulerAngles - offset;
		}
    }
	

}
