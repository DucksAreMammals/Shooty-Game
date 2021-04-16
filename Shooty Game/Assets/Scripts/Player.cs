using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
  [SerializeField] public float speed = 5f;
  [SerializeField] public float minPos = -8.5f;
  [SerializeField] public float maxPos = 8.5f;

  [SerializeField] public GameObject bullet;
  [SerializeField] public float timeBetweenBullets = 0.5f;
  [SerializeField] public float bulletSpawnYOffset = -0.3f;

  private float timeOfLastBullet = 0f;

  void Update()
  {
    float translation = Input.GetAxis("Horizontal") * speed;
    translation *= Time.deltaTime;
    transform.Translate(translation, 0, 0);

    if (transform.position.x < minPos) {
      transform.position = new Vector3(minPos, transform.position.y, 0);
    } else if (transform.position.x > maxPos) {
      transform.position = new Vector3(maxPos, transform.position.y, 0);
    }

    if (Input.GetKey("space") && canShoot()) {
      shoot();
    }
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
