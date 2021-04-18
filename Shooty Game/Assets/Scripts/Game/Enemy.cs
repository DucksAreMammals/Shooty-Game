using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
  [SerializeField] public int hp = 1;
  [SerializeField] public int score = 1;

  void Update() {
    transform.Translate(0, -5 * Time.deltaTime, 0);
  }

  public void Damage(int damage) {
    hp -= damage;

    if (hp <= 0) {
      Die();
    }
  }

  private void Die() {
    GameObject.Find("ScoreCounter").GetComponent<ScoreCounter>().AddPoints(score);

    Destroy(gameObject);
  }
}
