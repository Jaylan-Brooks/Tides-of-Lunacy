using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SandcastleHealth : MonoBehaviour
{
    [Header ("References")]
    [SerializeField] private Image healthbar;

    private float health = 500;
    private float maxHealth;

    void Start(){
      maxHealth = health;
   }

    void Update(){
        if (health <= 0){
            Lose();
        }
    }

    public void TakeDamage(int damage){
		health -= damage;
        healthbar.fillAmount = health / maxHealth;
	}

    private void Lose(){
		Destroy(gameObject);
        return;
	}

}
