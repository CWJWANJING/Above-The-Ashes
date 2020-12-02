using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GetHealth : MonoBehaviour
{
    public Text ui;

    private double shootSpeed = 1;
    private double shootTimer = 0;
    private double shootTimeInterval = 0;

    private GameObject target;

    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        target = player;
        ui.text = "";
        shootTimeInterval = 1 / shootSpeed;

    }

    // Update is called once per frame
    void Update()
    {
        shootTimer += Time.deltaTime;
        if (Vector3.Distance(gameObject.transform.position, target.transform.position) < 1.5)
        {
            if (Input.GetKey("f") && (shootTimer > shootTimeInterval))
            {
                target.GetComponent<PlayerSystem>().healthPoint += 10;
                print("Get Health");
                shootTimer = 0;

            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            ui.text = "Press F to Health!";
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            ui.text = "";
        }
    }
}
