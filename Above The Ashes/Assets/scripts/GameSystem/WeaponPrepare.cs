using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPrepare : MonoBehaviour
{
    // Init GameObject
    private GameObject gs;
    public GameObject camera;
    private GameObject player;
    public GameObject weapon_ready;
    public GameObject weapon_notR;
    public GameObject fire_PT;    

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        gs = GameObject.FindGameObjectWithTag("GS");// Get GameSystem scripts
        player = GameObject.FindGameObjectWithTag("Player");// Get Player Object

        if (camera.GetComponent<TPSCamera>().isAiming)
        {
            // Aiming to activate weapon
            weapon_ready.SetActive(true);
            weapon_notR.SetActive(false);
        }
        else {
            // disactivate weapon
            weapon_ready.SetActive(false);
            weapon_notR.SetActive(true);
        }

        if (player.GetComponent<PlayerSystem>().isShoot) {
            //Is shoot for player
            fire_PT.SetActive(true);// shoot particular effects
        }
        else {
            fire_PT.SetActive(false);// hide particular effects
        }

    }
}
