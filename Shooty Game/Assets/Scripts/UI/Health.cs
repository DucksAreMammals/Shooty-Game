using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
  private Player player;

  [SerializeField] GameObject heartPrefab;

  [SerializeField] Vector3 firstHeartPos;
  [SerializeField] Vector3 spacingBetweenHearts;

  [SerializeField] Sprite fullHeart;
  [SerializeField] Sprite emptyHeart;

  private List<GameObject> hearts = new List<GameObject>();

  private int previousHealth = -1;

  void Start() {
    player = GameObject.Find("Player").GetComponent<Player>();
  }

  void Update() {
    if (previousHealth != player.hp) {
      UpdateHealth();
      previousHealth = player.hp;
    }
  }

  void UpdateHealth() {
    foreach (GameObject heart in hearts) {
      Destroy(heart);
    }

    for (int i = 0; i < player.startingHealth; i++) {
      GameObject heart = Instantiate(heartPrefab, firstHeartPos + spacingBetweenHearts * i, Quaternion.identity);

      if (player.hp <= i) {
        heart.GetComponent<SpriteRenderer>().sprite = emptyHeart;
      } else {
        heart.GetComponent<SpriteRenderer>().sprite = fullHeart;
      }
      hearts.Add(heart);
    }
  }
}
