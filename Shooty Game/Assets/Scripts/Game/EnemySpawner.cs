using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
  [SerializeField] public GameObject enemy;
  [SerializeField] public int enemiesPerWave = 12;
  [SerializeField] public float timeBetweenWaves = 5f;
  [SerializeField] public float heightOfSpawn = 7f;
  [SerializeField] public float speedUpWaveRate = 0.01f;

  private float widthOfScreen = 8.9f * 2f - 1f;
  private float timeOfLastWave = -100f;

  void Update()
  {
    spawnWave();
    timeBetweenWaves -= Time.deltaTime * speedUpWaveRate;
  }

  void spawnWave() {
    // Check if wave can be spawned yet
    if(Time.time - timeOfLastWave > timeBetweenWaves) {
      float xPos = Random.Range(-widthOfScreen/2, widthOfScreen/2);
      Vector3 spawnPosition = new Vector3(xPos, heightOfSpawn, 0);
      Instantiate(enemy, spawnPosition, Quaternion.identity);

      timeOfLastWave = Time.time;
    }
  }
}
