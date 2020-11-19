using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chestcon : MonoBehaviour
{
    // get the "Click to open the chest" text
    public GameObject UIObject;
    private bool isOpen = false;
    private bool isMoving = false;
    public GameObject player;

    void Start()
    {
      // at first the text should not display
      UIObject.SetActive(false);
    }

    void Update()
      {
        // if player is closenough with this object
        if (Vector3.Distance(this.gameObject.transform.position, player.transform.position) < 3)
        {
          // show the instruction text
          UIObject.SetActive(true);
          // if the player press key F
          if (Input.GetKey("f"))
          {
            // if the animation is already moving, do nothing
            if (isMoving) {
              return;
            }
            isMoving = true;
            if (!isOpen) {
              // when player clicks on the chest, the chest lid will open
              GetComponent<Rigidbody>().angularVelocity= new Vector3(.8f,0,0);
              StartCoroutine(stopOpening());
            }
            else {
              GetComponent<Rigidbody>().angularVelocity= new Vector3(-.8f,0,0);
              StartCoroutine(stopOpening());
            }
         }

        }
        else{
          UIObject.SetActive(false);
        }
      }

    // this allows chest from continuing opening
    IEnumerator stopOpening()
    {
      yield return new WaitForSeconds (1.6f);
      GetComponent<Rigidbody>().angularVelocity= new Vector3(0,0,0);
      isOpen = !isOpen;
      isMoving = false;
    }
}
