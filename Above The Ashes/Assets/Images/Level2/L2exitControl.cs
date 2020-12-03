using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L2exitControl : MonoBehaviour
{

  Animator anim;
  // public TextMesh howmanykeys;
  // public static int N = 0;
  void Start()
  {
    anim = GetComponent<Animator>();
    // howmanykeys.gameObject.enabled = false;
  }

  void Update()
  {
    // show how many keys have been collected
    // Debug.Log(N);
    // if (N>0)
    // {
    //   howmanykeys.gameObject.enabled = true;
    //   howmanykeys.text = "Numer of keys found: "+N+ToString();
    // }

    if (L2key1.key1Found == true && L2key2.key2Found == true && L2key3.key3Found == true)
    {
      anim.SetTrigger("openL2door");
    }
  }

  void pauseAnimationEvent()
  {
    anim.enabled = false;
  }
}
