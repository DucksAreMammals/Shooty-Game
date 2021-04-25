using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shredder : MonoBehaviour
{
  [SerializeField] bool shredEnemies = false;

  void OnTriggerEnter2D(Collider2D other) {
    if (!(!shredEnemies && other.gameObject.tag == "Enemy")) {
      Destroy(other.gameObject);
    }
  }
}
