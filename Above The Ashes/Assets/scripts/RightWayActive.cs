using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightWayActive : MonoBehaviour
{
    public GameObject UIObject;
    public GameObject CubeWays;
    private bool isOpen = false;

    void Start()
    {
        // at first the text should not display
        UIObject.SetActive(false);
        CubeWays.SetActive(false);
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
            CubeWays.SetActive(true);
            isOpen = true;
        }
    }
}
