using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class ZombieWalk : MonoBehaviour
{
    public Vector3 vector3;
    public GameObject zombie;
    public float maxSpeed = 3;
    public float speed;
    public float BehState = 0;
    public GameObject eye;


    private GameObject target;
    private Animator animator;
    private Transform myTransform;


    private int WalkID = Animator.StringToHash("tracing");
    private int DeadState = Animator.StringToHash("Dead");
    private int AttackState = Animator.StringToHash("Attack");

    private void Awake()
    {
        myTransform = this.transform;
    }

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        target = player;
    }

    // Update is called once per frame
    void Update()
    {
        //Animation play
        if (zombie.GetComponent<EnemyState>().dis2Player > zombie.GetComponent<EnemyState>().sight && !zombie.GetComponent<EnemyState>().isDead)
        {
            BehState = 0;
            speed = 0;
        }
        else if (zombie.GetComponent<EnemyState>().dis2Player > zombie.GetComponent<EnemyState>().sight / 2
            && zombie.GetComponent<EnemyState>().dis2Player < zombie.GetComponent<EnemyState>().sight
            && !zombie.GetComponent<EnemyState>().isDead && ray2Player())
        {
            BehState = (float)(zombie.GetComponent<EnemyState>().dis2Player / (zombie.GetComponent<EnemyState>().sight / 2));
            speed = maxSpeed* (float)0.2;
        }
        else if (zombie.GetComponent<EnemyState>().dis2Player < zombie.GetComponent<EnemyState>().sight / 2
            && zombie.GetComponent<EnemyState>().dis2Player != zombie.GetComponent<EnemyState>().range
            && !zombie.GetComponent<EnemyState>().isDead && ray2Player())
        {
            BehState = (float)(zombie.GetComponent<EnemyState>().dis2Player / (zombie.GetComponent<EnemyState>().sight / 2));
            if(BehState <= 0.5) {
                BehState = (float)0.5;    
            }
            print(BehState);
            speed = maxSpeed * (float)0.6;
        }
        else if (zombie.GetComponent<EnemyState>().isAttack
            && !zombie.GetComponent<EnemyState>().isDead)
        {
            BehState = 0;
            speed = 0;
        }
        animator.SetFloat(WalkID, BehState);
        animator.SetBool(DeadState, zombie.GetComponent<EnemyState>().isDead);
        animator.SetBool(AttackState, zombie.GetComponent<EnemyState>().isAttack);

        //Walk
        if (!zombie.GetComponent<EnemyState>().isDead && ray2Player()){
              myTransform.rotation = Quaternion.Slerp(myTransform.rotation,
              Quaternion.LookRotation(target.transform.position - myTransform.position),
              90 * Time.deltaTime);
              transform.localPosition += transform.forward * Time.deltaTime * speed;
        }
        if (!ray2Player()) {
            BehState = 0;
            speed = 0;
        }
        
    }

    private bool ray2Player()
    {
        bool sight2player = false;
        Vector3 rayOrigin = eye.transform.position;
        RaycastHit hit;
        Vector3 rayTarget = (target.transform.position - rayOrigin).normalized;
        if (Physics.Raycast(rayOrigin, rayTarget, out hit, (target.transform.position - rayOrigin).magnitude))
        {
            Debug.DrawRay(rayOrigin, rayTarget);
            if (hit.collider.gameObject.tag == "Player")
            {
                sight2player = true;
                //print("Zombie can See Player");

            }
        }
        return sight2player;
    }
}
