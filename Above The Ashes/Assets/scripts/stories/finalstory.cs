using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class finalstory : MonoBehaviour
{
  public GameObject Text;
    // Start is called before the first frame update
    void Start()
    {

    }

    void OnTriggerEnter()
    {
      Text.SetActive(true);
    }

    void OnTriggerExit()
    {
      Text.SetActive(false);
    }
}
