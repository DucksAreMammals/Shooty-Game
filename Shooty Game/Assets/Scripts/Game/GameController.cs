using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
  private ScoreCounter scoreCounter;

  void Start() {
    scoreCounter = GameObject.Find("Canvas/ScoreCounter").GetComponent<ScoreCounter>();
  }

  public void AddPoints(int score) {
    scoreCounter.AddPoints(score);
  }
}
