using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerDoor3 : MonoBehaviour
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
      if (Level1switchC.door3open == false || Level1switchB.door3open == false)
      {
        anim.SetTrigger("closeTDoor3");
        alreadyOpen = false;
      }
    }else{
      if (Level1switchA.door3open == true || Level1switchD.door3open == true)
      {
        Debug.Log("open door 3");
        anim.SetTrigger("openTDoor3");
        alreadyOpen = true;
      }
    }
  }

  void pauseAnimationEvent()
  {
    anim.enabled = false;
  }
}
