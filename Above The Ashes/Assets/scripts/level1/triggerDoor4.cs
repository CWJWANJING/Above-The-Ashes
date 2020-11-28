using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerDoor4 : MonoBehaviour
{
  Animator anim;
  public bool alreadyOpen = false;
  // Start is called before the first frame update
  void Start()
  {
    anim = GetComponent<Animator>();
  }

  // Update is called once per frame
  void Update()
  {
    if (alreadyOpen == true)
    {
      if (Level1switchC.door4open == false)
      {
        anim.SetTrigger("closeTDoor4");
        alreadyOpen = false;
      }
    }
    else{
      if (Level1switchD.door4open == true)
      {
        Debug.Log("open door 4");
        anim.SetTrigger("openTDoor4");
        alreadyOpen = true;
      }
    }
  }

  void pauseAnimationEvent()
  {
    anim.enabled = false;
  }
}
