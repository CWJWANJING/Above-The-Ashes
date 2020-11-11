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

    public double shootSpeed = 0.1;
    private double shootTimer = 0;
    private double shootTimeInterval = 0;

    public Boolean isAttack = false;

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
        double dis2Player = (transform.position - gs.player.gameObject.transform.position).magnitude;
        shootTimer += Time.deltaTime;
        if ((shootTimer > shootTimeInterval) && isAttack && dis2Player <= range)
        {
            shootTimer = 0;
            gs.beAttack(gameObject);
            AttackInfo.text = "Be Attacked: " + attackPoint;        
            this.Invoke("textReset", 1);
        }

    }

    private void textReset() {
        AttackInfo.text = "";
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (gs.player.isAttack && collision.gameObject.tag == "Player")
        {
            gs.HitTo(gameObject);
        }
        
    }

}
