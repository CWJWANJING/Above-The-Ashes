using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L2key1 : MonoBehaviour
{
  public GameObject player;
  public GameObject UIObject;
  public GameObject key1;
  public static bool key1Found = false;

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
      if (Vector3.Distance(this.gameObject.transform.position, player.transform.position) < 1.7)
      {
        if (Input.GetKey("f"))
        {
          UIObject.SetActive(false);
          key1.SetActive(false);
          key1Found = true;
        }
      }

    }
    else{
      UIObject.SetActive(false);
    }
  }
}
