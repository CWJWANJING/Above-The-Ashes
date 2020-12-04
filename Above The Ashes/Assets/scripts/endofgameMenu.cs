using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class endofgameMenu : MonoBehaviour
{
  public static GameObject eogmenu;

    public void ReplayGame()
    {
      Debug.Log("replay");
      SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void QuitGame()
    {
      Debug.Log("Quit");
      Application.Quit();
    }
}
