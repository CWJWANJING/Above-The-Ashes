using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyState : MonoBehaviour
{
    public double healthPoint = 10;
    public double attackPoint = 2;
    public double range = 1;
    public double dis2Player;
    public double sight;

    public double shootSpeed = 0.1;
    private double shootTimer = 0;
    private double shootTimeInterval = 0;

    public Boolean isAttack = false;
    public Boolean isDead = false;
    public Boolean wantAttack = false;

    public Text AttackInfo;


    public GameSystem gs;
    // Start is called before the first frame update
    void Start()
    {
        shootTimeInterval = 1 / shootSpeed;
        AttackInfo.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        dis2Player = (transform.position - gs.player.gameObject.transform.position).magnitude;
        shootTimer += Time.deltaTime;
        if (dis2Player <= range && !gs.IsDead)
        {
            wantAttack = true;
        }
        else {
            wantAttack = false;
        }
        if ((shootTimer > shootTimeInterval) && wantAttack && dis2Player <= range && !isDead && !gs.IsDead)
        {
            shootTimer = 0;            
            isAttack = true;
            gs.beAttack(gameObject);
            AttackInfo.text = "Be Attacked: " + attackPoint;        
            this.Invoke("textReset", 1);
            this.Invoke("attackReset", (float)shootSpeed);
        }

    }

    private void textReset() {
        AttackInfo.text = "";
    }
    
    private void attackReset() {
        isAttack = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        //if (gs.player.isAttack && collision.gameObject.tag == "Player")
        //{
            //gs.HitTo(gameObject);
        //}
        
    }

}
