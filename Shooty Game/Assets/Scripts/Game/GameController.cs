using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameController : MonoBehaviour
{
  private ScoreCounter scoreCounter;

  void Start() {
    scoreCounter = GameObject.Find("Canvas/ScoreCounter").GetComponent<ScoreCounter>();
  }

  public void AddPoints(int score) {
    scoreCounter.AddPoints(score);
  }

  public void GameOver() {
    GameObject gameOver = GameObject.Find("Canvas/GameOver");
    gameOver.GetComponent<TextMeshProUGUI>().text = "You Died";
  }
}
