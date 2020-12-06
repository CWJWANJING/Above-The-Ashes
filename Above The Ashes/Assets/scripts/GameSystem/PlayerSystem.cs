using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerSystem : MonoBehaviour
{
    // Start is called before the first frame update
    //Player attribute initialization
    public double healthPoint = 10;
    public double ammo = 10;
    public double clip = 0;
    public double max_clip = 25;
    public double attackPoint = 5;
    public double range = 10;
    public double bulletSpeed = 20;

    // Timer initialization
    public double shootSpeed = 1;
    public double ReloadSpeed = 1;
    private double shootTimer = 0;
    private double ReloadTimer = 0;
    private double shootTimeInterval = 0;
    private double ReloadTimeInterval = 0;

    public Text PlayerUI;
    public Text HitMessage;

    // Operation object initialization
    public GameSystem gs;
    public TPSCamera TPSC;
    public AudioSource ads;
    public AudioSource ads_suffer;
    public AudioSource Reload_eff;
    public GameObject firePoint;

    // State initialization
    public Boolean isAttack = false;
    public Boolean isShoot = false;

    public bool gamePause = false;
    public GameObject PauseMenuUI;

    void Start()
    {
        PlayerUI.text = "";
        HitMessage.text = "";
        // Filling judgment after getting bullet
        if ((int)(ammo / max_clip) > 0)
        {
            clip = max_clip;
            ammo -= max_clip;
        }
        else {
            clip = ammo;
            ammo = 0;
        }

        // Timer start
        shootTimeInterval = 1 / shootSpeed;
        ReloadTimeInterval = 1 / ReloadSpeed;

    }

    // Update is called once per frame
    void Update()
    {
        //Calculate clips
        int clip_num = (int)(ammo / max_clip);        
        ReloadTimer += Time.deltaTime;

        // Change attack state
        if (Input.GetMouseButtonDown(0) && clip !=0) {
            isAttack = true;
        }
        if (Input.GetMouseButtonUp(0)) {
            isAttack = false;
        }

        // Reload condition judgemnent
        if (Input.GetKey("r") && ammo != 0 && clip != max_clip && !isAttack && (ReloadTimer > ReloadTimeInterval)) {
            reload();
            ReloadTimer = 0;
        }

        shootTimer += Time.deltaTime;
        // Fire condition judgement
        if ((shootTimer > shootTimeInterval) && isAttack && clip != 0 && TPSC.isAiming)
        {
            fire();
            isShoot = true;
            shootTimer = 0;
        }
        else {
            isShoot = false;
        }
        // Invoke pause menu
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

        // Player UI Display
        PlayerUI.text = "HP: " + healthPoint + "  Ammo:" + clip + "/" + max_clip + " Ammunition:" + clip_num + "*" + max_clip ;

    }

    // From pause menu to resume
    public void Resume()
    {
      PauseMenuUI.SetActive(false);
      Time.timeScale = 1f;
      gamePause = false;
    }

    // From game to pause menu
    public void Pause()
    {
      PauseMenuUI.SetActive(true);
      Time.timeScale = 0f;
      gamePause = true;
    }

    // Reload function for player
    private void reload()
    {
        Reload_eff.Play();// Reload effects
        if ((ammo - max_clip) <= 0) {
            // last ammo can't fill one clips
            clip = ammo;
            ammo = 0;// set ammo to 0
            if (clip < 0) {
                clip = 0;
            }
        }
        if ((ammo - max_clip) > 0) {
            // last ammo can fill one clips
            ammo = ammo - max_clip;// calculate last ammo
            clip = max_clip;// reload clips
        }
    }

    private void fire() {
        // Get fire point position
        Vector3 rayOrigin = firePoint.transform.position;
        // Get target postion
        Vector3 targetPosition = Camera.main.transform.position + Camera.main.transform.forward * (int)range;
        // Initilization RaycastHit
        RaycastHit hit;
        clip -= 1;// Reduce ammo in clips
        ads.Play();// Fire effects
        if (Physics.Raycast(rayOrigin, Camera.main.transform.forward, out hit, (int)range))
            // Fire by raycast. Get Raycast Hit
        {
            if (hit.collider.gameObject.tag == "Zombie") 
            // If we hit Zombie
            {
                gs.HitTo(hit.collider.gameObject);// Take damages
                ads_suffer.Play();// Hit effects
                HitMessage.text = "Take demage to " + hit.collider.gameObject.tag + " :" + attackPoint;// Test UI
                this.Invoke("ResetMessage", (float)0.5);//  Reset test UI
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
