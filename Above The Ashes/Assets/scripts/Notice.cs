using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Notice : MonoBehaviour
{
    // get the notice text
    public Text noticeText;
    public GameObject player;

    void Start()
    {
        // at first the text should not display
        noticeText.text = "";
    }

    private void Update()
    {
        if ((gameObject.transform.position - player.transform.position).magnitude <= 3)
        {
            if (gameObject.tag == "Zombie")
            {
                noticeText.text = "Stay away from him!";
            }
            else if (gameObject.tag == "Break")
            {
                noticeText.text = "Why don't you try to hit it?";

            }
            else
            {
                noticeText.text = "";
            }
        }
        else
        {
            noticeText.text = "";
        }




    }

}
