using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class autoDoorControl : MonoBehaviour
{

    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
      anim = GetComponent<Animator>();
    }

    void OnTriggerEnter(Collider other)
    {
      anim.SetTrigger("openDoor");
    }

    void OnTriggerExit(Collider other)
    {
      anim.enabled = true;
    }

    void pauseAnimationEvent()
    {
      anim.enabled = false;
    }
}
