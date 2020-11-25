using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerAutoDoor : MonoBehaviour
{

    Animator anim;
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
        anim.SetTrigger("openTriggerDoor");
      }
    }

    void pauseAnimationEvent()
    {
      anim.enabled = false;
    }
}
