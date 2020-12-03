using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPrepare : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject gs;
    public GameObject camera;
    private GameObject player;
    public GameObject weapon_ready;
    public GameObject weapon_notR;
    public GameObject fire_PT;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        gs = GameObject.FindGameObjectWithTag("GS");
        player = GameObject.FindGameObjectWithTag("Player");

        if (camera.GetComponent<TPSCamera>().isAiming)
        {
            weapon_ready.SetActive(true);
            weapon_notR.SetActive(false);
        }
        else {
            weapon_ready.SetActive(false);
            weapon_notR.SetActive(true);
        }

        if (player.GetComponent<PlayerSystem>().isShoot) {
            fire_PT.SetActive(true);
        }
        else {
            fire_PT.SetActive(false);
        }

    }
}
