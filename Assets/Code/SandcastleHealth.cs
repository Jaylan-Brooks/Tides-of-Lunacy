using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SandcastleHealth : MonoBehaviour
{
    [Header ("References")]
    [SerializeField] private Image healthbar;
    [SerializeField] private GameObject deadCastle;

    private float health = 500f;

    void Start(){
      health = 500f;
   }

    void Update(){
        if (health <= 0){
            Lose();
        }
    }

    public void TakeDamage(int damage){
		health -= damage;
        healthbar.fillAmount = health / 500f;
	}

    private void Lose(){
        deadCastle.SetActive(true);
        LevelManager.main.GetComponent<AudioManager>().Play("Death Pop");
		Destroy(gameObject);
        return;
	}

}
