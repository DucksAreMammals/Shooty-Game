using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
  [SerializeField] public GameObject enemy;
  [SerializeField] public int enemiesPerWave = 10;
  [SerializeField] public float timeBetweenWaves = 5f;
  [SerializeField] public float heightOfSpawn = 7f;

  private float widthOfScreen = 8.9f * 2f - 1f;
  private float timeOfLastWave = -100f;

  void Update()
  {
    spawnWave();
  }

  void spawnWave() {
    // Check if wave can be spawned yet
    if(Time.time - timeOfLastWave > timeBetweenWaves) {

      // Spawn wave of enemies
      for (int i = 0; i < enemiesPerWave; i++) {
        float xPos = -(widthOfScreen / 2) + (widthOfScreen / enemiesPerWave) * i;
        Vector3 spawnPosition = new Vector3(xPos, heightOfSpawn, 0);
        Instantiate(enemy, spawnPosition, Quaternion.identity);
      }

      timeOfLastWave = Time.time;
    }
  }
}
