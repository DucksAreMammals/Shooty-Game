using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
  [SerializeField] public float bulletSpeed = 10f;

  void Setup() {

  }

  void Update() {
    transform.Translate(0, bulletSpeed * Time.deltaTime, 0);
  }

  void OnTriggerEnter2D(Collider2D col) {
    Debug.Log("done");
    Destroy(gameObject);
  }
}
