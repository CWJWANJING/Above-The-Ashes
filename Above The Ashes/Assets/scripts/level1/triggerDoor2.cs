using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerDoor2 : MonoBehaviour
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
    if (alreadyOpen == true){
      if (Level1switchC.door2open == false || Level1switchD.door2open == false)
      {
        anim.SetTrigger("closeTDoor2");
        alreadyOpen = false;
      }
    }else{
      if (Level1switchB.door2open == true)
      {
        Debug.Log("open door 2");
        anim.SetTrigger("openTDoor2");
        alreadyOpen = true;
      }
    }
  }

  void pauseAnimationEvent()
  {
    anim.enabled = false;
  }
}
