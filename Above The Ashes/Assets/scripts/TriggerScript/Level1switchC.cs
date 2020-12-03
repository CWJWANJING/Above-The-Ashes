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

	private Vector3 offset = new Vector3 (0.0f, 2.0f,0.0f);
	private bool trigger;
	private double shootTimer = 0;
    private double shootTimeInterval = 0.1;

	private double Timer2 = 0;
	private double TimeInterval2 = 1.5;

	private double Timer3 = 0;
	private double TimeInterval3 = 1.5;


    void Start()
    {
        // at first the text should not display
        UIObject.SetActive(false);
		trigger = false;
		//print("C");
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
					print("Change false");
					Timer3 = 0;
				}
				else{
					print("Change true");
					trigger = true;
					Timer2 = 0;
				}
					shootTimer = 0;
				}



			}

		}else{
        UIObject.SetActive(false);
		}
		if(trigger)
		{
		    //print(trigger);
			Timer2 += Time.deltaTime;
			if (Timer2 < TimeInterval2) {
				// print("A");
				ActionA();
			}

		}
		else{
			Timer3 += Time.deltaTime;
			if (Timer3 < TimeInterval3) {
				// print("B");
				//ActionB();
			}

		}
    }



	void ActionA(){

		if(Door1.transform.localEulerAngles.y >= 87f&&Door1.transform.localEulerAngles.y < 178f){
			Door1.transform.localEulerAngles = Door1.transform.localEulerAngles + offset;
		}

		if(Door2.transform.localEulerAngles.y <= 183f&&Door2.transform.localEulerAngles.y > 92f){
			Door2.transform.localEulerAngles = Door2.transform.localEulerAngles - offset;
		}

		if(Door3.transform.localEulerAngles.y <= 183f&&Door3.transform.localEulerAngles.y > 92f){
			Door3.transform.localEulerAngles = Door3.transform.localEulerAngles - offset;
		}

		if(Door4.transform.localEulerAngles.y <= 183f&&Door4.transform.localEulerAngles.y > 92f){
			Door4.transform.localEulerAngles = Door4.transform.localEulerAngles - offset;
		}

    }



}
