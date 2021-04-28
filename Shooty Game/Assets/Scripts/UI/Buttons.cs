using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
  public void Quit() {
    Application.Quit();
  }

  public void Play() {
    SceneManager.LoadScene("Game");
  }

  public void Attribution() {
    SceneManager.LoadScene("Attribution");
  }

  public void MainMenu() {
    SceneManager.LoadScene("Main Menu");
  }
}
