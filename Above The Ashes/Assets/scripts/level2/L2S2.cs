using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L2S2 : MonoBehaviour
{
    public GameObject UIObject;
  	public GameObject Door3;
  	public GameObject player;
  	private Vector3 offset = new Vector3 (0.0f, 1.0f,0.0f);
  	private bool trigger;

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
				trigger = true;

			}

				//door3open = true;

		}else{
        UIObject.SetActive(false);
		}
		if(trigger)
		{
		    print(trigger);
			ActionA();
		}

    }


	void ActionA(){

		if(Door3.transform.localEulerAngles.y >= 270f&&Door3.transform.localEulerAngles.y < 360f){
			Door3.transform.localEulerAngles = Door3.transform.localEulerAngles + offset;
		}
    }


}
