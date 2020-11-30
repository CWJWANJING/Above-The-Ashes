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
    public double clip = 0;
    public double max_clip = 25;
    public double attackPoint = 5;
    public double range = 10;
    public double bulletSpeed = 20;

    public double shootSpeed = 1;
    public double ReloadSpeed = 1;
    private double shootTimer = 0;
    private double ReloadTimer = 0;
    private double shootTimeInterval = 0;
    private double ReloadTimeInterval = 0;

    public Text PlayerUI;
    public Text HitMessage;

    public GameSystem gs;
    public TPSCamera TPSC;
    public AudioSource ads;
    public AudioSource ads_suffer;
    public AudioSource Reload_eff;
    public GameObject firePoint;

    public Boolean isAttack = false;

    public static bool gamePause = false;
    public GameObject PauseMenuUI;

    void Start()
    {
        PlayerUI.text = "";
        HitMessage.text = "";
        if ((int)(ammo / max_clip) > 0)
        {
            clip = max_clip;
            ammo -= max_clip;
        }
        else {
            clip = ammo;
            ammo = 0;
        }
        shootTimeInterval = 1 / shootSpeed;
        ReloadTimeInterval = 1 / ReloadSpeed;

    }

    // Update is called once per frame
    void Update()
    {
        int clip_num = (int)(ammo / max_clip);        
        ReloadTimer += Time.deltaTime;

        if (Input.GetMouseButtonDown(0) && clip !=0) {
            isAttack = true;
        }
        if (Input.GetMouseButtonUp(0)) {
            isAttack = false;
        }

        if (Input.GetKey("r") && ammo != 0 && clip != max_clip && !isAttack && (ReloadTimer > ReloadTimeInterval)) {
            reload();
            ReloadTimer = 0;
        }

        shootTimer += Time.deltaTime;
        if ((shootTimer > shootTimeInterval) && isAttack && clip != 0 && TPSC.isAiming) {
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
        PlayerUI.text = "HP: " + healthPoint + "  Ammo:" + clip + "/" + max_clip + " Ammunition:" + clip_num + "*" + max_clip ;

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

    private void reload()
    {
        Reload_eff.Play();
        if ((ammo - max_clip) <= 0) {
            clip = ammo;
            ammo = 0;
            if (clip < 0) {
                clip = 0;
            }
        }
        if ((ammo - max_clip) > 0) {
            ammo = ammo - max_clip;
            clip = max_clip;
        }
    }

    private void fire() {
        //计算准星的位置
        //Vector3 rayOrigin = Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0));
        Vector3 rayOrigin = firePoint.transform.position;
        print(rayOrigin);
        Vector3 targetPosition = Camera.main.transform.position + Camera.main.transform.forward * (int)range;
        RaycastHit hit;
        clip -= 1;
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
