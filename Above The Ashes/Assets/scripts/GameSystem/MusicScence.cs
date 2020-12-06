using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MusicScence : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource BGM;
    public AudioSource Battle;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        // Start cheasing music
        if (other.gameObject.tag == "Player") {
            Battle.volume = 1;
            BGM.volume = 0;
        }
    }

    void OnTriggerExit(Collider other)
    {
        // Switch it to Normal BGM
        Battle.volume = 0;
        BGM.volume = 1;
    }
}
