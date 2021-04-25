using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shredder : MonoBehaviour
{
  [SerializeField] bool shredEnemies = false;
  [SerializeField] GameController gameController;

  void Start() {
    gameController = GameObject.Find("GameController").GetComponent<GameController>();
  }

  void OnTriggerEnter2D(Collider2D other) {
    if (!(!shredEnemies && other.gameObject.tag == "Enemy")) {
      Destroy(other.gameObject);
    }

    if (other.gameObject.tag == "Enemy") {
      gameController.EnemyDie(0);
    }
  }
}
