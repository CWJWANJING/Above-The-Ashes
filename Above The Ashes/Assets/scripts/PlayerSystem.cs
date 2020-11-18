using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerSystem : MonoBehaviour
{
    // Start is called before the first frame update
    public double healthPoint = 10;
    public double ammo = 10;
    public double attackPoint = 5;
    public double range = 10;
    public double bulletSpeed = 20;

    public double shootSpeed = 1;
    private double shootTimer = 0;
    private double shootTimeInterval = 0;

    public Text PlayerUI;
    public Text HitMessage;

    public GameSystem gs;
    public TPSCamera TPSC;
    public AudioSource ads;
    public AudioSource ads_suffer;
    public GameObject firePoint;

    public Boolean isAttack = false;

    public static bool gamePause = false;
    public GameObject PauseMenuUI;

    void Start()
    {
        PlayerUI.text = "";
        HitMessage.text = "";
        shootTimeInterval = 1 / shootSpeed;

    }

    // Update is called once per frame
    void Update()
    {
        PlayerUI.text = "HP: " + healthPoint + "  Ammo:" + ammo + " Attack:" + isAttack;
        if (Input.GetMouseButtonDown(0) && ammo !=0) {
            isAttack = true;
        }
        if (Input.GetMouseButtonUp(0)) {
            isAttack = false;
        }
        shootTimer += Time.deltaTime;
        if ((shootTimer > shootTimeInterval) && isAttack && ammo != 0 && TPSC.isAiming) {
            fire();
            shootTimer = 0;
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
          if (gamePause){
            Resume();
          }
          else
          {
            Pause();
          }
        }

    }

    public void Resume()
    {
      PauseMenuUI.SetActive(false);
      Time.timeScale = 1f;
      gamePause = false;
    }

    public void Pause()
    {
      PauseMenuUI.SetActive(true);
      Time.timeScale = 0f;
      gamePause = true;
    }

    private void fire() {
        //计算准星的位置
        //Vector3 rayOrigin = Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0));
        Vector3 rayOrigin = firePoint.transform.position;
        print(rayOrigin);
        Vector3 targetPosition = Camera.main.transform.position + Camera.main.transform.forward * (int)range;
        RaycastHit hit;
        ammo -= 1;
        ads.Play();
        if (Physics.Raycast(rayOrigin, Camera.main.transform.forward, out hit, (int)range))
        {
            if (hit.collider.gameObject.tag == "Zombie") {
                gs.HitTo(hit.collider.gameObject);
                ads_suffer.Play();
                HitMessage.text = "Take demage to " + hit.collider.gameObject.tag + " :" + attackPoint;
                this.Invoke("ResetMessage", (float)0.5);
            }
            targetPosition = hit.point;
        }


    }

    public void ResetMessage() {
        HitMessage.text = "";
    }

    void OnTriggerEnter(Collider other)
    {

        //if (gs.player.isAttack && other.tag == "Zombie")
        //{
           // gs.HitTo(gameObject);
        //}
    }

    private void OnTriggerStay(Collider other)
    {

    }




}
