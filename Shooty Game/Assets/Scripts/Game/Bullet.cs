using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
  [SerializeField] public float bulletSpeed = 10f;
  [SerializeField] public int hp = 1;
  [SerializeField] public bool isPlayerBullet = false;
  [SerializeField] public GameObject bulletParticles;
  [SerializeField] public float particleYOffset = 0.3f;

  [SerializeField] public GameObject breakParticles;
  [SerializeField] public float breakParticleYOffset = 0.3f;

  private GameObject particles;

  void Start() {
    particles = Instantiate(bulletParticles, transform.position, Quaternion.identity);
    if (isPlayerBullet) {
      particles.transform.localEulerAngles = new Vector3(0, 0, 180);
    }
  }

  void Update() {
    GetComponent<Rigidbody2D>().velocity = new Vector3(0, bulletSpeed, 0);
    particles.transform.position = new Vector3(transform.position.x, transform.position.y - particleYOffset, transform.position.z);
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
      if (breakParticles != null) {
        Vector3 pos = new Vector3(transform.position.x, transform.position.y + breakParticleYOffset, transform.position.z);
        GameObject objectBreakParticles = Instantiate(breakParticles, pos, Quaternion.identity);
        Destroy(objectBreakParticles, 3);
      }
      Destroy(particles);
      Destroy(gameObject);
    }
  }
}
