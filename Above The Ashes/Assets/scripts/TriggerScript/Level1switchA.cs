using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1switchA : MonoBehaviour
{
    public GameObject UIObject;
    public GameObject Door3;
	public GameObject player;
    private bool isOpen = false;

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
        if (isOpen)
        {
            return;
        }
        else
        {
            Door3.SetActive(false);
            isOpen = false;
        }
    }
	
	void Update()
    {
      // if player is closenough with this object
		if (Vector3.Distance(this.gameObject.transform.position, player.transform.position) < 1.5)
		{
			UIObject.SetActive(true);
		
			if (Input.GetKey("f"))
			{
				Door3.SetActive(false);
			}
			
        }
		else{
        UIObject.SetActive(false);
		}
    }
}
