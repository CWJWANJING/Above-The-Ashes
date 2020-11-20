using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1switchB : MonoBehaviour
{
    public GameObject UIObject;
    public GameObject Door2;
	public GameObject Door3;
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
            Door2.SetActive(false);
			Door3.SetActive(true);
            isOpen = false;
        }
    }
}
