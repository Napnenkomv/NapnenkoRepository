using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

  public class Manager : MonoBehaviour
{
    public void ResetPressed()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void MainMenuPressed()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
