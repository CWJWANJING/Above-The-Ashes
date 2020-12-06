using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class ZombieWalk : MonoBehaviour
{
    // Init GameObject
    public Vector3 vector3;
    public GameObject zombie;
    public float maxSpeed = 3;
    public float speed;
    public float BehState = 0;// From 0 to 2. from stand to run
    public GameObject eye;


    private GameObject target;
    private Animator animator;
    private Transform myTransform;

    // Init params in state machine
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
        animator = GetComponent<Animator>();// Get animator(State Machine)
        GameObject player = GameObject.FindGameObjectWithTag("Player");// Get player
        target = player;
    }

    // Update is called once per frame
    void Update()
    {
        GameObject gs = GameObject.FindGameObjectWithTag("GS");// Get GameSystem Machine
        //Animation play
        if (zombie.GetComponent<EnemyState>().dis2Player > zombie.GetComponent<EnemyState>().sight && !zombie.GetComponent<EnemyState>().isDead)
        {
            // Normal state of zombie: Can't see player and zombie not die
            BehState = 0;
            speed = 0;
        }
        else if (zombie.GetComponent<EnemyState>().dis2Player > zombie.GetComponent<EnemyState>().sight / 2
            && zombie.GetComponent<EnemyState>().dis2Player < zombie.GetComponent<EnemyState>().sight
            && !zombie.GetComponent<EnemyState>().isDead && ray2Player() && !gs.GetComponent<GameSystem>().IsDead)
        {
            // Chease state of Zombie: Far from player but zombie can see it

            //Zombie try to run to hit player
            BehState = (float)(zombie.GetComponent<EnemyState>().dis2Player / (zombie.GetComponent<EnemyState>().sight / 2));
            speed = maxSpeed* (float)0.2;// try to run
        }
        else if (zombie.GetComponent<EnemyState>().dis2Player < zombie.GetComponent<EnemyState>().sight / 2
            && zombie.GetComponent<EnemyState>().dis2Player != zombie.GetComponent<EnemyState>().range
            && !zombie.GetComponent<EnemyState>().isDead && ray2Player() && !gs.GetComponent<GameSystem>().IsDead)
        {
            // Chease state of Zombie: near from player and zombie can see it

            // Zombie try to walk to hit player
            BehState = (float)(zombie.GetComponent<EnemyState>().dis2Player / (zombie.GetComponent<EnemyState>().sight / 2));
            if(BehState <= 0.5) {
                // Define Mini speed and state
                BehState = (float)0.5;    
            }
            speed = maxSpeed;// Define speed for zombie of animation
        }
        else if (zombie.GetComponent<EnemyState>().isAttack
            && !zombie.GetComponent<EnemyState>().isDead && !gs.GetComponent<GameSystem>().IsDead)
        {
            // Zmobie is dead: Do nothing
            BehState = 0;
            speed = 0;
        }

        // Update Params in state machine
        animator.SetFloat(WalkID, BehState);
        animator.SetBool(DeadState, zombie.GetComponent<EnemyState>().isDead);
        animator.SetBool(AttackState, zombie.GetComponent<EnemyState>().isAttack);

        //Walk to player
        if (!zombie.GetComponent<EnemyState>().isDead && ray2Player()){
            // Change direction
              myTransform.rotation = Quaternion.Slerp(myTransform.rotation,
              Quaternion.LookRotation(target.transform.position - myTransform.position),
              90 * Time.deltaTime);
              transform.localPosition += transform.forward * Time.deltaTime * speed;
        }
        if (!ray2Player()) {
            // Can't see player (Blocked by obstacles)
            BehState = 0;
            speed = 0;
        }
        if (gs.GetComponent<GameSystem>().IsDead)
        {
            // Zmobie is dead: Do nothing
            BehState = 0;
            speed = 0;
        }

    }

    // Check can't zmobie sight player
    private bool ray2Player()
    {
        bool sight2player = false;
        Vector3 rayOrigin = eye.transform.position;// init position of zombie's eyes
        RaycastHit hit;
        Vector3 rayTarget = (target.transform.position - rayOrigin).normalized;// ray's direction
        int layerMask = 9 | 10;// Define which layer can be raycast
        if (Physics.Raycast(rayOrigin, rayTarget, out hit,(target.transform.position - rayOrigin).magnitude, layerMask))
        {
            Debug.DrawRay(rayOrigin, rayTarget);
            if (hit.collider.gameObject.tag == "Player")
            {
                sight2player = true;
                //Zombie can See Player

            }
        }
        return sight2player;
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Break some obstacles to get more Oppression
        if (collision.gameObject.layer == 9)
        {
            Destroy(collision.gameObject);
        }
    }

}
