using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class buttonCon : MonoBehaviour
{

    public Image hintImage;

    void Start()
    {
      hintImage.enabled = false;
    }

    void OnTriggerEnter(Collider other)
    {
        // when player is near the chest
        if (other.tag == "Player")
        {
            // show the text
            hintImage.enabled = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        // when player leaves the trigger, text disappear
        hintImage.enabled = false;
    }
}
