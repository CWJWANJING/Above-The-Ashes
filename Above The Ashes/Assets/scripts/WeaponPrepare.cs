using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPrepare : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject gs;
    private GameObject camera;
    private GameObject player;
    public GameObject weapon_ready;
    public GameObject weapon_notR;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        gs = GameObject.FindGameObjectWithTag("GS");
        player = GameObject.FindGameObjectWithTag("Player");
        camera = GameObject.FindGameObjectWithTag("MainCamera");

        if (camera.GetComponent<TPSCamera>().isAiming)
        {
            weapon_ready.SetActive(true);
            weapon_notR.SetActive(false);
        }
        else {
            weapon_ready.SetActive(false);
            weapon_notR.SetActive(true);
        }

    }
}
