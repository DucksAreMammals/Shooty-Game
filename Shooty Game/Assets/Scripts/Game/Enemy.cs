using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
  [SerializeField] public int hp = 1;
  [SerializeField] public int score = 1;
  [SerializeField] public float bulletSpawnOffsetY = -0.7f;
  [SerializeField] public float speed = -3f;

  [SerializeField] public GameObject bullet;
  [SerializeField] public float minTimeBetweenBullets = 0.5f;
  [SerializeField] public float maxTimeBetweenBullets = 2f;

  private float timeOfNextBullet;
  [SerializeField] public float yPosStartShooting = 5f;

  void Start() {
    GetComponent<Rigidbody2D>().velocity = new Vector3(0, speed, 0);

    timeOfNextBullet = Time.time + Random.Range(0, maxTimeBetweenBullets);
  }

  void Update() {
    if (Time.time > timeOfNextBullet && transform.position.y < yPosStartShooting) {
      shoot();
      UpdateNextBulletTime();
    }
  }

  private void UpdateNextBulletTime() {
    timeOfNextBullet = Time.time + Random.Range(minTimeBetweenBullets, maxTimeBetweenBullets);
  }

  public void Damage(int damage) {
    hp -= damage;

    if (hp <= 0) {
      Die();
    }
  }

  private void Die() {
    GameObject.Find("GameController").GetComponent<GameController>().EnemyDie(score);
    Destroy(gameObject);
  }

  void shoot() {
    Vector3 pos = new Vector3(transform.position.x, transform.position.y + bulletSpawnOffsetY, transform.position.z + 1);

    Instantiate(bullet, pos, Quaternion.identity);
  }
}
