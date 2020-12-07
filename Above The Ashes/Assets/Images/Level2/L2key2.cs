using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L2key2 : MonoBehaviour
{
  public GameObject player;
  public GameObject UIObject;
  public GameObject key2;
  public static bool key2Found = false;

  // Start is called before the first frame update
  void Start()
  {
    // at first the text should not display
    Debug.Log("setting key 2 to false");
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
      if (Vector3.Distance(this.gameObject.transform.position, player.transform.position) < 2)
      {
        // if key F is pressed
        if (Input.GetKey("f"))
        {
          // instruction texts should disappear
          UIObject.SetActive(false);
          key2.SetActive(false);
          key2Found = true;
        }
      }
    }
    else{
      UIObject.SetActive(false);
    }
  }
}
