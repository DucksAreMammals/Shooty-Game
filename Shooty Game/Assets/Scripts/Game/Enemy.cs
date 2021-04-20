using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
  [SerializeField] public int hp = 1;
  [SerializeField] public int score = 1;
  [SerializeField] public float bulletSpawnOffsetY = -0.7f;

  [SerializeField] public GameObject bullet;
  [SerializeField] public float minTimeBetweenBullets = 0.5f;
  [SerializeField] public float maxTimeBetweenBullets = 2f;

  private float timeOfLastBullet = -100f;
  [SerializeField] public float timeBetweenBullets;

  void Start() {
    timeBetweenBullets = Random.Range(minTimeBetweenBullets, maxTimeBetweenBullets);
  }

  void Update() {
    transform.Translate(0, -5 * Time.deltaTime, 0);

    if (Time.time - timeOfLastBullet > timeBetweenBullets) {
      shoot();
      timeOfLastBullet = Time.time;
    }
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

  void shoot() {
    Vector3 pos = new Vector3(transform.position.x, transform.position.y + bulletSpawnOffsetY, transform.position.z);

    Instantiate(bullet, pos, Quaternion.identity);
  }
}
