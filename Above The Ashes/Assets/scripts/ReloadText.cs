using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReloadText : MonoBehaviour
{
    public GameObject rt;
    public PlayerSystem ps;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (ps.clip != 0) {
            rt.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        rt.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        rt.SetActive(false);
    }
}
