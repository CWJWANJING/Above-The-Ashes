using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pauseMenu : MonoBehaviour
{
    public static bool gamePause = false;
    public GameObject PauseMenuUI;

    // Update is called once per frame
    void Update()
    {
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
    }

    public void Resume()
    {
      PauseMenuUI.SetActive(false);
      Time.timeScale = 1f;
      gamePause = false;

    }

    void Pause()
    {
      PauseMenuUI.SetActive(true);
      Time.timeScale = 0f;
      gamePause = true;
      // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
      Debug.Log("Quit");
      Application.Quit();
    }
}
