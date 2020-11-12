using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class buttonCon : MonoBehaviour
{

    public Image hintImage;

    void Start()
    {
      Debug.Log("Start.");
      hintImage.gameObject.SetActive(false);
    }

    void OnTriggerEnter()
    {
      Debug.Log("Enter.");
      hintImage.gameObject.SetActive(true);
    }

    void OnTriggerExit()
    {
      Debug.Log("Leave.");
        // when player leaves the trigger, text disappear
      hintImage.gameObject.SetActive(false);
    }
}
