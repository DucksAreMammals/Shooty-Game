using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
  [SerializeField] public float hp = 1f;

  void Update() {
    transform.Translate(0, -5 * Time.deltaTime, 0);
  }

  public void Damage(float damage) {
    hp -= damage;

    if (hp <= 0) {
      Die();
    }
  }

  private void Die() {
    Destroy(gameObject);
  }
}
