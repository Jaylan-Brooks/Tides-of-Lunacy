using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiscinoidMind : MonoBehaviour
{
    [Header ("References")]
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Animator animator;
    [SerializeField] private GameObject attackPrefab;
    [SerializeField] private Transform hitPoint;
    [SerializeField] private GameObject deathPop;

    [Header ("Attributes")]
    [SerializeField] private bool invinciblity;
    [SerializeField] private bool boss;
    [SerializeField] private float speed;
    [SerializeField] private int health;
    [SerializeField] private int towerDamage;
    [SerializeField] private string soundEffect;

    private bool invincible;

    void Start(){
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        rb.velocity = new Vector2(-speed, 0);
        if (invinciblity && boss){
            invinciblity = false;
            boss = false;
        }
        if (invinciblity){
            invincible = true;
        }
    }

    void Update(){
        if (health <= 0){
            Die();
        }
    }

    private void OnTriggerEnter2D (Collider2D collider){
        if (collider.gameObject.tag == "Tidepal"){
            if (!boss){
                rb.velocity = Vector2.zero;
                animator.SetBool("Tidepal", true);
                if (invinciblity){
                    invincible = false;
                }
            }
        }
		if (collider.gameObject.tag == "Castle"){
            collider.gameObject.GetComponent<SandcastleHealth>().TakeDamage(towerDamage);
            if (!boss){
                Die();
            }
        }
    }

    private void OnTriggerExit2D (Collider2D collider){
        if (collider.gameObject.tag == "Tidepal"){
            if (boss){
                collider.gameObject.GetComponent<TidepalMind>().TakeDamage(towerDamage);
            }
            else {
                if (collider.gameObject.GetComponent<TidepalMind>().ReturnHealth() <= 0){
                    rb.velocity = new Vector2(-speed, 0);
                    animator.SetBool("Tidepal", false);
                    if (invinciblity){
                       invincible = true;
                    }
                }
            }
        }
    }

    private void Attack(){
        GameObject attackObj = Instantiate(attackPrefab, hitPoint.position, Quaternion.identity);
        LevelManager.main.GetComponent<AudioManager>().Play(soundEffect);
    }

    public void TakeDamage(int damage){
		health -= damage;
        if (boss){
            animator.SetInteger("Health", health);
        }
	}

    public int ReturnHealth(){
		return health;
	}

    public bool IsInvincible(){
		return invincible;
	}

    private void Die(){
        if (boss){
            rb.constraints = RigidbodyConstraints2D.None;
            rb.constraints = RigidbodyConstraints2D.FreezeRotation | RigidbodyConstraints2D.FreezePositionX;
            rb.gravityScale = 2;
            LevelManager.main.GetComponent<AudioManager>().Play(soundEffect);
        }
        else{
            GameObject burst = Instantiate(deathPop, GetComponent<Transform>().position, Quaternion.identity);
            Destroy(gameObject);
            return;
        }
	}
}