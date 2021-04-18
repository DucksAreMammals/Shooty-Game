using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreCounter : MonoBehaviour
{
  [SerializeField] int score = 0;
  private TextMeshProUGUI text;

  void Start() {
    text = GetComponent<TextMeshProUGUI>();
  }

  public void AddPoints(int points) {
    score += points;
    text.text = score.ToString();
  }
}
