using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class b3 : MonoBehaviour
{
  public GameObject Text;
    // Start is called before the first frame update
    void Start()
    {
        Text.SetActive(false);
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
