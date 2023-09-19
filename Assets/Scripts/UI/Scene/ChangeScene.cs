using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public void ReloadScene()
    {
      SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
      Time.timeScale = 1;
    }

    public void ReturnMainScene()
    {
      SceneManager.LoadScene(0);
      Time.timeScale = 1;
    }
}
