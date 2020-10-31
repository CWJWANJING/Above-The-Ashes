using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chestcon : MonoBehaviour
{
    // get the "Click to open the chest" text
    public GameObject UIObject;
    private bool isOpen = false;
    private bool isMoving = false;

    void Start()
    {
      // at first the text should not display
      UIObject.SetActive(false);
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

    void OnMouseDown()
    {
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

    // this allows chest from continuing opening
    IEnumerator stopOpening()
    {
      yield return new WaitForSeconds (1.6f);
      GetComponent<Rigidbody>().angularVelocity= new Vector3(0,0,0);
      isOpen = !isOpen;
      isMoving = false;
    }
}
