using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class puzzleControl : MonoBehaviour
{

    public Transform[] images;
    public static bool win = false;
    public static bool win_state = false;

    // Update is called once per frame
    void Update()
    {
        GameObject puzzle = GameObject.FindGameObjectWithTag("Puzzle");

        // only when the puzzles are all back to the original position
        if (images[0].rotation.z == 0 &&
         images[1].rotation.z == 0 &&
         images[2].rotation.z == 0 &&
         images[3].rotation.z == 0 &&
         images[4].rotation.z == 0 &&
         images[5].rotation.z == 0 &&
         images[6].rotation.z == 0 &&
         images[7].rotation.z == 0 &&
         images[8].rotation.z == 0 &&
         images[9].rotation.z == 0 &&
         images[10].rotation.z == 0 &&
         images[11].rotation.z == 0
         )
         {
            puzzle.GetComponent<showPuzzleWeapon>().playPuzzle = false;
            win = true;
            win_state = true;
            Debug.Log("Win.");
         }
    }


}
