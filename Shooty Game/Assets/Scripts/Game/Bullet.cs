using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
  [SerializeField] public float bulletSpeed = 10f;
  [SerializeField] public int hp = 1;

  void Update() {
    transform.Translate(0, bulletSpeed * Time.deltaTime, 0);
  }

  void OnTriggerEnter2D(Collider2D other) {
    try {
      Enemy enemy = other.gameObject.GetComponent<Enemy>();
      enemy.Damage(hp);
    } catch {
      try {
        Player player = other.gameObject.GetComponent<Player>();
        player.Damage(hp);
      } catch {}
    }

    Destroy(gameObject);
  }
}
