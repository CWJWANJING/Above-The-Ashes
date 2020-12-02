using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class puzzleControl : MonoBehaviour
{

    public Transform[] images;
    public static bool win = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
      if(images[0].rotation.z == 0 &&
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
           win = true;
           Debug.Log("Win.");
         }
    }


}
