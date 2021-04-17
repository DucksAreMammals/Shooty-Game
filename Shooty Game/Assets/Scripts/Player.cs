using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
  [SerializeField] public int startingHealth = 3;
  public int hp;

  [SerializeField] public float speed = 5f;
  [SerializeField] public float minPos = -8.5f;
  [SerializeField] public float maxPos = 8.5f;

  [SerializeField] public GameObject bullet;
  [SerializeField] public float timeBetweenBullets = 0.5f;
  [SerializeField] public float bulletSpawnYOffset = -0.3f;

  private float timeOfLastBullet = 0f;

  void Start()
  {
    hp = startingHealth;
  }

  void Update()
  {
    // Move based on getaxis
    float translation = Input.GetAxis("Horizontal") * speed;
    translation *= Time.deltaTime;
    transform.Translate(translation, 0, 0);

    // Restrict movement to screen area
    if (transform.position.x < minPos) {
      transform.position = new Vector3(minPos, transform.position.y, 0);
    } else if (transform.position.x > maxPos) {
      transform.position = new Vector3(maxPos, transform.position.y, 0);
    }

    // Shoot if space is pressed and can shoot
    if (Input.GetKey("space") && canShoot()) {
      shoot();
    }
  }

  void OnTriggerEnter2D(Collider2D other) {
    Enemy enemy = other.gameObject.GetComponent<Enemy>();

    int enemyHp = enemy.hp;

    enemy.Damage(hp);
    Damage(enemyHp);
  }

  public void Damage(int damage) {
    hp -= damage;

    if (hp <= 0) {
      Die();
    }
  }

  public void Die() {
    Destroy(gameObject);
  }

  private bool canShoot() {
    return Time.time - timeOfLastBullet > timeBetweenBullets;
  }

  private void shoot() {
    timeOfLastBullet = Time.time;
    Vector3 bulletPosition = new Vector3(transform.position.x, transform.position.y + bulletSpawnYOffset, 1);
    Instantiate(bullet, bulletPosition, Quaternion.identity);
  }
}
