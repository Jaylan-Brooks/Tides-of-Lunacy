using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Header ("References")]
    [SerializeField] private Rigidbody2D rb;

    [Header ("Attributes")]
    [SerializeField] private bool unbreakable;
    [SerializeField] private float speed;
    [SerializeField] private int damage;

    void Start(){
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(speed, 0);
    }

    private void OnTriggerEnter2D (Collider2D collider){
        if (collider.gameObject.tag == "Piscinoid"){
            if (!collider.gameObject.GetComponent<PiscinoidMind>().IsInvincible()){
                collider.gameObject.GetComponent<PiscinoidMind>().TakeDamage(damage);
                if (!unbreakable){
                    Break();
                }
            }  
        }
        if (collider.gameObject.tag == "NoBullet"){
            Break();
        }
    }

    private void OnTriggerExit2D (Collider2D collider){
        if (unbreakable){
            if (collider.gameObject.tag == "Piscinoid"){
                if (!collider.gameObject.GetComponent<PiscinoidMind>().IsInvincible()){
                    collider.gameObject.GetComponent<PiscinoidMind>().TakeDamage(damage);
                }
            }
        }
    }

    private void Break(){
		Destroy(gameObject);
        return;
	}
}
