using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blueradiate : MonoBehaviour
{
    [Header ("Attributes")]
    [SerializeField] private float payTime;
    
    private float loopTime = 0f;
    private float blueraySpawnTime;
    private int addBluerays;
    private bool payed = false;
    private int deposit = 0;

    void FixedUpdate(){
        if (!payed){
            Deposit(deposit);
        }
        loopTime += Time.deltaTime;
        if (loopTime > payTime){
            loopTime = 0f;
            RandomizeSpawnTime();
            RandomizeDeposit();
            payed = false;
        }
    }

    private void RandomizeSpawnTime(){
        blueraySpawnTime = Random.value * payTime+1;
    }

    private void RandomizeDeposit(){
        float random = Random.value;
        deposit = 3;
        if (random <= 0.10f){
            deposit = 1;
        }
        if (random > 0.10f && random <= 0.30f){
            deposit = 2;
        }
        if (random > 0.30f && random <= 0.70f){
            deposit = 3;
        }
        if (random > 0.70f && random <= 0.90f){
            deposit = 4;
        }
        if (random > 0.90f){
            deposit = 5;
        }
    }

    private void Deposit(int bluerays){
      if (Mathf.FloorToInt(blueraySpawnTime) == Mathf.FloorToInt(loopTime)){
        LevelManager.main.IncreaseBluerays(bluerays);
        payed = true;
      }
   }

}
