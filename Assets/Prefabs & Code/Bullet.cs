using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Header ("References")]
    [SerializeField] private Rigidbody2D rb;

    [Header ("Attributes")]
    [SerializeField] private float speed;
    [SerializeField] private int damage;

    void Start(){
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(speed, 0);
    }

    private void OnTriggerEnter2D (Collider2D collider){
        if (collider.gameObject.tag == "Piscinoid"){
            collider.gameObject.GetComponent<PiscinoidMind>().TakeDamage(damage);
            Break();
        }
        if (collider.gameObject.tag == "Bullet Death"){
            Break();
        }
    }

    private void Break(){
		Destroy(gameObject);
        return;
	}
}
