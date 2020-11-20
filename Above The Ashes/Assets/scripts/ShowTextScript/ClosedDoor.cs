using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClosedDoor : MonoBehaviour
{
  //public Image puzzleImage;
  public GameObject player;
  public GameObject UIObject;
  void Start()
  {
    // at first the puzzle should not display
    //puzzleImage.gameObject.SetActive(false);
    // at first the text should not display
    UIObject.SetActive(false);
  }

  void Update()
    {
      // if player is closenough with this object
      if (Vector3.Distance(this.gameObject.transform.position, player.transform.position) < 3)
      {
        UIObject.SetActive(true);
      }
      else{
        UIObject.SetActive(false);
      }
    }

}
