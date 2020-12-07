using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L2key3 : MonoBehaviour
{
  public GameObject player;
  public GameObject UIObject;
  public GameObject key3;
  public static bool key3Found = false;

  // Start is called before the first frame update
  void Start()
  {
    // at first the text should not display
    UIObject.SetActive(false);
  }

  // Update is called once per frame
  void Update()
  {
    // if player is closenough with this object
    if (Vector3.Distance(this.gameObject.transform.position, player.transform.position) < 3)
    {
      // tell user to press f to pick up
      UIObject.SetActive(true);
      // if player is close enough with the key
      if (Vector3.Distance(this.gameObject.transform.position, player.transform.position) < 2)
      {
        if (Input.GetKey("f"))
        {
          UIObject.SetActive(false);
          key3.SetActive(false);
          key3Found = true;
        }
      }

    }
    else{
      UIObject.SetActive(false);
    }

  }
}
