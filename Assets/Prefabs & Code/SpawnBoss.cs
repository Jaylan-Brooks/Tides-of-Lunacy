using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBoss : MonoBehaviour
{
    [Header ("References")]
    [SerializeField] private GameObject[] bossPrefabs;

    void Start(){
        TurnOn();
    }

    void FixedUpdate(){
      if (LevelManager.main.IsBossTime()){
        Spawn(0);
      }
   }

   private void Spawn(int index){
        GameObject fish = bossPrefabs[index];
        Instantiate(fish, transform.position, Quaternion.identity);
        TurnOff();
   }

   public void TurnOff(){
      enabled = false;
   }

   public void TurnOn(){
      enabled = true;
   }
}
