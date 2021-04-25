using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameController : MonoBehaviour
{
  private ScoreCounter scoreCounter;
  private GameObject[] enemies;

  void Start() {
    scoreCounter = GameObject.Find("Canvas/ScoreCounter").GetComponent<ScoreCounter>();
  }

  public void EnemyDie(int score) {
    AddPoints(score);

     GameObject.FindGameObjectsWithTag("Respawn");
  }

  private void AddPoints(int score) {
    scoreCounter.AddPoints(score);
    enemies = GameObject.FindGameObjectsWithTag("Enemy");

    // Length is 1 because this is called before the enemy destroys itself
    if (enemies.Length <= 1) {
      Win();
    }
  }

  private void Win() {
    GameObject gameOver = GameObject.Find("Canvas/GameOver");
    gameOver.GetComponent<TextMeshProUGUI>().text = "You Win!";
  }

  public void GameOver() {
    GameObject gameOver = GameObject.Find("Canvas/GameOver");
    gameOver.GetComponent<TextMeshProUGUI>().text = "You Died";
  }
}
