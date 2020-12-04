using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class finalscript : MonoBehaviour
{
    public GameObject UIObject;
  	public GameObject img;
  	public GameObject s1;public GameObject s2;public GameObject s3;public GameObject s4;public GameObject s5;
  	public GameObject img1;public GameObject img2;public GameObject img3;public GameObject img4;
  	public float moveSpeed;
    public GameObject plane;
  	public GameObject player;
  	public double t1;
  	public double t2;
  	public double t3;

  	private Vector3 offset = new Vector3 (0.05f, 0.03f,0.0f);
  	private Vector3 offset1 = new Vector3 (-1f, 1f,0.0f);
  	private bool trigger;
  	private double shootTimer = 0;
  	private double TimeInterval1 = 4.0;

    // end of game is false
    public static bool eogmenuTrigger = false;

    public GameObject eogmenu;


    void Start()
    {
        // at first the text should not display
        UIObject.SetActive(false);
		    trigger = false;

    }


    void Update()
    {
       // print(trigger);
	   if (Vector3.Distance(this.gameObject.transform.position, player.transform.position) < 3){
  			UIObject.SetActive(true);
  			if(Input.GetKey("f")){
  				trigger = true;
  				shootTimer = 0;
  				player.SetActive(false);
  			}

		}else{
        UIObject.SetActive(false);
		}
		if(trigger)
		{
			shootTimer += Time.deltaTime;
			ActionA();
			if (shootTimer > TimeInterval1&&shootTimer<=(TimeInterval1+0.2)) {
					img.SetActive(true);
				}
			if (shootTimer > (TimeInterval1+0.2)&&shootTimer<=(TimeInterval1+0.2+t1)) {
					s1.SetActive(true);
				}
			if (shootTimer > (TimeInterval1+0.2+t1)&&shootTimer<=(TimeInterval1+0.2+t1*2)) {
					s2.SetActive(true);
				}
			if (shootTimer > (TimeInterval1+0.2+t1*2)&&shootTimer<=(TimeInterval1+0.2+t1*3)) {
					s3.SetActive(true);
				}
			if (shootTimer > (TimeInterval1+0.2+t1*3)&&shootTimer<=(TimeInterval1+0.2+t1*3+t2)) {
					s1.SetActive(false);
					s2.SetActive(false);
					s3.SetActive(false);
				}
			if (shootTimer > (TimeInterval1+0.2+t1*3+t2)&&shootTimer<=(TimeInterval1+0.2+t1*3+t2+t3)) {
					img1.SetActive(true);
				}
			if (shootTimer > (TimeInterval1+0.2+t1*3+t2+t3)&&shootTimer<=(TimeInterval1+0.2+t1*3+t2+t3*2)) {
					img1.SetActive(false);
					img2.SetActive(true);
				}
			if (shootTimer > (TimeInterval1+0.2+t1*3+t2+t3*2)&&shootTimer<=(TimeInterval1+0.2+t1*3+t2+t3*3)) {
					img2.SetActive(false);
					img3.SetActive(true);
				}
			if (shootTimer > (TimeInterval1+0.2+t1*3+t2+t3*3)&&shootTimer<=(TimeInterval1+0.2+t1*3+t2+t3*4)) {
					img3.SetActive(false);
					img4.SetActive(true);
				}
			if (shootTimer > (TimeInterval1+0.2+t1*3+t2+t3*4)&&shootTimer<=(TimeInterval1+0.2+t1*3+t2+t3*4+t1)) {
					img4.SetActive(false);
					s4.SetActive(true);
				}
			if (shootTimer > (TimeInterval1+0.2+t1*3+t2+t3*4+t1)&&shootTimer<=(TimeInterval1+0.2+t1*3+t2+t3*4+t1*2)) {
					img4.SetActive(false);
					s5.SetActive(true);
				}
      if (shootTimer > (TimeInterval1+0.2+t1*3+t2+t3*4+t1*2)&&shootTimer<=(TimeInterval1+0.2+t1*3+t2+t3*4+t1*3)) {
          s4.SetActive(false);
          s5.SetActive(false);
          Debug.Log("eog is true");
          eogmenu.SetActive(true);
          eogmenuTrigger = true;
        }
		}

    }


	void ActionA(){
		// print("move");
		transform.position = transform.position + offset * moveSpeed;
		//transform.Translate(offset * Time.deltaTime);
    }

	void ActionB(){

		if(plane.transform.localEulerAngles.y <= 181f&&plane.transform.localEulerAngles.y > 91f){
			plane.transform.localEulerAngles = plane.transform.localEulerAngles - offset;
		}
		if(plane.transform.localEulerAngles.y >= 1f&&plane.transform.localEulerAngles.y < 91f){
			plane.transform.localEulerAngles = plane.transform.localEulerAngles - offset;
		}
    }


}
