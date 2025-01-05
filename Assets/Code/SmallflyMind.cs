using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallflyMind : MonoBehaviour
{
    [Header ("References")]
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private GameObject deathPop;

    [Header ("Attributes")]
    [SerializeField] private float speed;
    [SerializeField] private int damage;
    [SerializeField] private int towerDamage;

    void Start(){
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(-speed, 0);
    }

    private void OnTriggerEnter2D (Collider2D collider){
        if (collider.gameObject.tag == "Tidepal"){
            collider.gameObject.GetComponent<TidepalMind>().TakeDamage(damage);
            Die();
        }
        if (collider.gameObject.tag == "Castle"){
            collider.gameObject.GetComponent<SandcastleHealth>().TakeDamage(towerDamage);
            Die();
        }
    }

    private void Die(){
        GameObject burst = Instantiate(deathPop, GetComponent<Transform>().position, Quaternion.identity);
		Destroy(gameObject);
        return;
	}
}
