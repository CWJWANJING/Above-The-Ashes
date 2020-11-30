using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameSystem : MonoBehaviour
{
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

    public void beAttack(GameObject enemy)
    {
        double hp_temp = player.healthPoint - enemy.GetComponent<EnemyState>().attackPoint;
        if (hp_temp <= 0)
        {
            player.healthPoint = 0;
            ads_long.Play();
            IsDead = true;            
            DeadMessage.SetActive(true);
            this.Invoke("Reset", 3);

        }
        else {
            player.healthPoint = hp_temp;
            ads_short.Play();

        }
    }

    public void HitTo(GameObject enemy)
    {
        double New_enem_hp = enemy.GetComponent<EnemyState>().healthPoint - player.attackPoint;
        if (New_enem_hp <= 0)
        {
            enemy.GetComponent<EnemyState>().healthPoint = 0;
            ads_long.Play();
            Death(enemy);
        }
        else {
            enemy.GetComponent<EnemyState>().healthPoint = New_enem_hp;
            ads_short.Play();

        }
    }

    public void Death(GameObject body) {
        body.GetComponent<EnemyState>().isDead = true;
        Destroy(body.GetComponent<BoxCollider>());
        this.Invoke("deleteBody", 5);
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
