using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameSystem : MonoBehaviour
{
    // Variable initialization
    public PlayerSystem player;
    public GameObject DeadMessage;
    public AudioSource ads_short;
    public AudioSource ads_long;

    public bool IsDead = false;



    // Start is called before the first frame update
    void Start()
    {
        IsDead = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    // The player's health is updated after being attacked
    public void beAttack(GameObject enemy)
    {
        double hp_temp = player.healthPoint - enemy.GetComponent<EnemyState>().attackPoint;
        if (hp_temp <= 0)
        {
            // Died after being hit
            player.healthPoint = 0;
            ads_long.Play();// Hit sound
            IsDead = true;            
            DeadMessage.SetActive(true);
            this.Invoke("Reset", 3);

        }
        else {
            // Will not die after being hit
            player.healthPoint = hp_temp;
            ads_short.Play();// Hit sound

        }
    }

    // The player deals damage to the target
    public void HitTo(GameObject enemy)
    {
        double New_enem_hp = enemy.GetComponent<EnemyState>().healthPoint - player.attackPoint;
        if (New_enem_hp <= 0)
        {
            // Direct death of the target
            enemy.GetComponent<EnemyState>().healthPoint = 0;
            ads_long.Play();// Hit sound
            Death(enemy);
        }
        else {
            // Target still alive
            enemy.GetComponent<EnemyState>().healthPoint = New_enem_hp;
            ads_short.Play();// Hit sound

        }
    }

    // Target death
    public void Death(GameObject body) {
        body.GetComponent<EnemyState>().isDead = true;// Change the state
        Destroy(body.GetComponent<BoxCollider>());// Delete GameObject
        this.Invoke("deleteBody", 5);// Delete body
    }

    public void deleteBody(GameObject body) {
        Destroy(body);
    }

    public void Reset()
    {
        DeadMessage.SetActive(false);
        SceneManager.LoadScene(0);
    }




}
