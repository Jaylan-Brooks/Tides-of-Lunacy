using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiscinoidMind : MonoBehaviour
{
    [Header ("References")]
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Animator animator;
    [SerializeField] private GameObject hitbox;

    [Header ("Attributes")]
    [SerializeField] private float speed;
    [SerializeField] private int health;
    [SerializeField] private int towerDamage;

    void Start(){
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        rb.velocity = new Vector2(-speed, 0);
    }

    void Update(){
        if (health <= 0){
            Die();
        }
    }

    private void OnTriggerEnter2D (Collider2D collider){
        if (collider.gameObject.tag == "Tidepal"){
            rb.velocity = Vector2.zero;
            animator.SetBool("Tidepal", true);
        }
		if (collider.gameObject.tag == "Castle"){
            collider.gameObject.GetComponent<SandcastleHealth>().TakeDamage(towerDamage);
            Die();
        }
    }

    private void OnTriggerExit2D (Collider2D collider){
        if (collider.gameObject.tag == "Tidepal"){
            if (collider.gameObject.GetComponent<TidepalMind>().ReturnHealth() <= 0){
                rb.velocity = new Vector2(-speed, 0);
                animator.SetBool("Tidepal", false);
            }
        }
    }

    private void HitboxOn(){
        hitbox.transform.Translate(0.5f, 0.0f, 0.0f);
	}

    private void HitboxOff(){
        hitbox.transform.Translate(-0.5f, 0.0f, 0.0f);
	}

    public void TakeDamage(int damage){
		health -= damage;
	}

    public int ReturnHealth(){
		return health;
	}

    private void Die(){
		Destroy(gameObject);
        return;
	}
}