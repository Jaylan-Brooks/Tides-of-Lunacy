using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPiscinoidSky : MonoBehaviour
{
   [Header ("References")]
   [SerializeField] private GameObject[] enemyPrefabs;

   private float enemySpawnTime;
   private int currentWave = 1;
   private float timeUntilSpawnReroll = 10.0f;
   private float currentTime = 0f;
   private float loopTime = 0f;
   private bool spawned = true;
   private int enemy = 0;

   void Start(){
        TurnOn();
        currentTime = 0f;
        loopTime = 0f;
   }

   void FixedUpdate(){
      if (!spawned){
        Spawn(enemy);
      }
      currentTime += Time.deltaTime;
      loopTime += Time.deltaTime;
      ScaleDifficulty();
      if (loopTime > timeUntilSpawnReroll){
         loopTime = 0f;
         RandomizeSpawnTime();
         enemy = RandomizeEnemy();
         spawned = false;
      }
   }

   private void ScaleDifficulty(){
      if (currentTime <= 30.0f){
         currentWave = 1;
         timeUntilSpawnReroll = 30.0f;
      }
      if (currentTime > 30.0f && currentTime <= 60.00f){
         currentWave = 2;
         timeUntilSpawnReroll = 6.0f;
      }
      if (currentTime > 60.0f && currentTime <= 120.0f){
         currentWave = 3;
         timeUntilSpawnReroll = 5.0f;
      }
      if (currentTime > 120.0f && currentTime <= 180.0f){
         currentWave = 4;
         timeUntilSpawnReroll = 5.0f;
      }
      if (currentTime > 180.0f && currentTime <= 240.0f){
         currentWave = 5;
         timeUntilSpawnReroll = 9.0f;
      }
      if (currentTime > 240.0f && currentTime <= 300.0f){
         currentWave = 6;
         timeUntilSpawnReroll = 9.0f;
      }
      if (currentTime > 300.0f && currentTime <= 360.0f){
         currentWave = 7;
         timeUntilSpawnReroll = 7.0f;
      }
      if (currentTime > 360.0f && currentTime <= 420.0f){
         currentWave = 8;
         timeUntilSpawnReroll = 7.0f;
      }
      if (currentTime > 420.0f && currentTime <= 480.0f){
         currentWave = 9;
         timeUntilSpawnReroll = 5.0f;
      }
      if (currentTime > 480.0f){
         TurnOff();
      }
   }

   private void RandomizeSpawnTime(){
      enemySpawnTime = Random.value * timeUntilSpawnReroll;
   }

   private int RandomizeEnemy(){
      float random = Random.value;
      int enemy = -1;
      if (currentWave == 1){
         enemy = -1;
      }
      if (currentWave == 2){
         if (random <= 0.80f){
            enemy = -1;
         }
         if (random > 0.80f){
            enemy = 0;
         }
      }
      if (currentWave == 3 || currentWave == 4){
         if (random <= 0.50f){
            enemy = -1;
         }
         if (random > 0.50f){
            enemy = 0;
         }
      }
      if (currentWave == 5){
         if (random <= 0.60f){
            enemy = 0;
         }
         if (random > 0.60f){
            enemy = 1;
         }
      }
      if (currentWave == 6){
         if (random <= 0.75f){
            enemy = 0;
         }
         if (random > 0.75f){
            enemy = 1;
         }
      }
      if (currentWave >= 7){
         if (random <= 0.80f){
            enemy = 0;
         }
         if (random > 0.20f){
            enemy = 1;
         }
      }
      return enemy;
   }

   private void Spawn(int index){
      if (Mathf.FloorToInt(enemySpawnTime) == Mathf.FloorToInt(loopTime)){
        if (index == -1){
            spawned = true;
        }
        else {
         GameObject fish = enemyPrefabs[index];
         Instantiate(fish, transform.position, Quaternion.identity);
         spawned = true;
        }
      }
   }

   public void TurnOff(){
      currentTime = 0;
      enabled = false;
   }

   public void TurnOn(){
      enabled = true;
   }
}
