using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerDoor1 : MonoBehaviour
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
        return;
      }
      else{
        if (Level1switchC.door1open == true)
        {
          Debug.Log("open door 1");
          anim.SetTrigger("openTDoor1");
          alreadyOpen = true;
        }
      }
    }

    void pauseAnimationEvent()
    {
      Debug.Log("should pause");
      anim.enabled = false;
      Debug.Log("paused?");
    }
}
