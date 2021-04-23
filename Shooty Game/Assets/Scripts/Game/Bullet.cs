using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
  [SerializeField] public float bulletSpeed = 10f;
  [SerializeField] public int hp = 1;
  [SerializeField] public bool isPlayerBullet = false;

  void Update() {
    GetComponent<Rigidbody2D>().velocity = new Vector3(0, bulletSpeed, 0);
  }

  void OnTriggerEnter2D(Collider2D other) {
    if (isPlayerBullet && other.gameObject.tag == "Enemy") {
      Enemy enemy = other.gameObject.GetComponent<Enemy>();
      enemy.Damage(hp);
    } else if (!isPlayerBullet && other.gameObject.tag == "Player") {
      Player player = other.gameObject.GetComponent<Player>();
      player.Damage(hp);
    }

    // save if other == bullet
    //   or if other is enemy and I am an enemy bullet
    if (!(other.gameObject.tag == "Bullet" || (other.gameObject.tag == "Enemy" && !isPlayerBullet))) {
      Destroy(gameObject);
    }
  }
}
