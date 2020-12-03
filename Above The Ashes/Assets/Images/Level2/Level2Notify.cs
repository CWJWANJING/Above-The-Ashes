using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2Notify : MonoBehaviour
{
  public GameObject player;
  public GameObject UIObject;

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
    }
    else{
      UIObject.SetActive(false);
    }
  }
}
