using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blueradiate : MonoBehaviour
{
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
        if (loopTime > 5f){
            loopTime = 0f;
            RandomizeSpawnTime();
            RandomizeDeposit();
            payed = false;
        }
    }

    private void RandomizeSpawnTime(){
        blueraySpawnTime = Random.value * 6;
    }

    private void RandomizeDeposit(){
        float random = Random.value;
        deposit = 3;
        if (random <= 0.20f){
            deposit = 1;
        }
        if (random > 0.20f && random <= 0.40f){
            deposit = 2;
        }
        if (random > 0.40f && random <= 0.60f){
            deposit = 3;
        }
        if (random > 0.60f && random <= 0.80f){
            deposit = 4;
        }
        if (random > 0.80f){
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
