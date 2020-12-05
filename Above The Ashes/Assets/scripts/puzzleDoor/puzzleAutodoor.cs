using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class puzzleAutodoor : MonoBehaviour
{

    Animator anim;
    public PlayerSystem ps;
    // Start is called before the first frame update
    void Start()
    {
      anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
      if (puzzleControl.win)
      {
        anim.SetTrigger("openDoor");
      }
        if (puzzleControl.win_state) {
            ps.ammo = 25;
            puzzleControl.win_state = false;
            this.enabled = false;
        }
    }

    void pauseAnimationEvent()
    {
      anim.enabled = false;
    }
}
