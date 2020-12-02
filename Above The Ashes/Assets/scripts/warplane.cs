using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class warplane : MonoBehaviour
{
  Animator anim;
  public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
      anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
      // if player is closenough with this object
      if (Vector3.Distance(this.gameObject.transform.position, player.transform.position) < 3)
      {
        if (Input.GetKey("f"))
        {
          // player disappear
          player.SetActive(false);
          // plane flys away
          anim.SetTrigger("flyaway");
        }
      }
    }

    void pauseAnimationEvent()
    {
      anim.enabled = false;
    }
}
