using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class showPuzzleWeapon : MonoBehaviour
{
  public Image puzzleImage;
  public GameObject player;
  public GameObject UIObject;
  public bool playPuzzle = false;

  void Start()
  {
    // at first the puzzle should not display
    puzzleImage.gameObject.SetActive(false);
    // at first the text should not display
    UIObject.SetActive(false);
  }

  void Update()
    {
        GameObject puzzle = GameObject.FindGameObjectWithTag("Puzzle");

        // if player is closenough with this object
        if (Vector3.Distance(this.gameObject.transform.position, player.transform.position) < 3)
      {
        // if player already solved the puzzle
        if (puzzleControl.win){
          // the puzzle image will disappear
          puzzleImage.gameObject.SetActive(false);
          // player will back to normal, unfrozen
          Time.timeScale = 1f;
          // there will be no text instructing player
          UIObject.SetActive(false);
        }
        // if player haven't solve the puzzle
        else{
          // show the instructions to player
          UIObject.SetActive(true);
          // if player started to play the puzzle
          if (playPuzzle){
            // the text will disappear
            UIObject.SetActive(false);
          }
          // if the player press key F
          if (Input.GetKey("f"))
          {
            // puzzle shows, cursor shows
            Cursor.visible = true;
            playPuzzle = true;
            // other things will stop
            Time.timeScale = 0f;
            // the puzzle will appear
            puzzleImage.gameObject.SetActive(true);
          }
          // if key q is pressed
          if (Input.GetKey("q"))
          {
            // // puzzle disappear, cursor disappers
            // Cursor.visible = false;
            // image will disappear
            puzzleImage.gameObject.SetActive(false);
            puzzle.GetComponent<showPuzzleWeapon>().playPuzzle = false;
                    // everything will back to normal, unfrozen
            Time.timeScale = 1f;
          }
        }
      }
      else{
        UIObject.SetActive(false);
      }
    }

}
