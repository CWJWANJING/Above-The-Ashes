using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameSystem : MonoBehaviour
{
    public PlayerSystem player;
    public GameObject DeadMessage;


    // Start is called before the first frame update
    void Start()
    {
        
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
            DeadMessage.SetActive(true);
            this.Invoke("Reset", 3);

        }
        else {
            player.healthPoint = hp_temp;
        }
    }

    public void HitTo(GameObject enemy)
    {
        double New_enem_hp = enemy.GetComponent<EnemyState>().healthPoint - player.attackPoint;
        if (New_enem_hp <= 0)
        {
            enemy.GetComponent<EnemyState>().healthPoint = 0;
            Death(enemy);
        }
        else {
            enemy.GetComponent<EnemyState>().healthPoint = New_enem_hp;
        }
        print("Enemy hp: " + enemy.GetComponent<EnemyState>().healthPoint);
    }

    public void Death(GameObject body) {
        Destroy(body);
    }

    public void Reset()
    {
        DeadMessage.SetActive(false);
        SceneManager.LoadScene(0);
    }




}
