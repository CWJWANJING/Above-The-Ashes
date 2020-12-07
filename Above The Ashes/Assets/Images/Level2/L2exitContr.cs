using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L2exitContr : MonoBehaviour
{

  Animator anim;
  void Start()
  {
    anim = GetComponent<Animator>();
  }

  void Update()
  {
    // if all three keys have been collected
    if (L2key1.key1Found == true && L2key2.key2Found == true && L2key3.key3Found == true)
    {
      // play open door animation
      anim.SetTrigger("openL2door");
    }
  }

  // the door will open, and won't be closed
  void pauseAnimationEvent()
  {
    anim.enabled = false;
  }
}
