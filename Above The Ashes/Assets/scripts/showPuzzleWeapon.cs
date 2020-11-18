using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class showPuzzleWeapon : MonoBehaviour
{
  public Image puzzleImage;
  public GameObject player;

  void Start()
  {
    puzzleImage.gameObject.SetActive(false);
  }

  void Update()
    {
      // if player is closenough with this object
      if (Vector3.Distance(this.gameObject.transform.position, player.transform.position) < 3)
      {
        // if the player press key F
        if (Input.GetKey("f"))
        {
          // other things will stop
          Time.timeScale = 0f;
            // the puzzle will appear
            puzzleImage.gameObject.SetActive(true);
        }
        // if player success in the puzzle
        if (puzzleControl.win)
        {
          // the puzzle image will disappear
          puzzleImage.gameObject.SetActive(false);
          Time.timeScale = 1f;
        }

        // if escape key is pressed
        if (Input.GetKey(KeyCode.Escape))
        {
          // image will disappear
          puzzleImage.gameObject.SetActive(false);
          Time.timeScale = 1f;
        }

      }
    }

}
