using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TidepalMind : MonoBehaviour
{
    [Header ("References")]
    [SerializeField] private Animator animator;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform firingPoint;
    [SerializeField] private GameObject hitbox;
    [SerializeField] private LayerMask enemyMask;

    [Header ("Attributes")]
    [SerializeField] private bool ranged;
    [SerializeField] private bool melee;
    [SerializeField] private bool support;
    [SerializeField] private int health;
    [SerializeField] private float lineOfSight;

    void Start(){
        animator = GetComponent<Animator>();
        if ((!ranged && !melee) || (ranged && melee) || (support && (ranged || melee))){
            support = true;
        }
    }

    void Update(){
        if (ranged && !melee && !support){
            SpotPiscinoid();
        }
        if (health <= 0){
            Die();
        }
    }

    private void SpotPiscinoid(){
        RaycastHit2D hit = Physics2D.Raycast(firingPoint.position, Vector2.right, lineOfSight, enemyMask);
        if (hit.collider != null){
            if (hit.collider.gameObject.tag == "Piscinoid"){
                animator.SetBool("Piscinoid", true);
	        }
        }
        else {
            animator.SetBool("Piscinoid", false);
        }
    }

    private void Shoot(){
        GameObject bulletObj = Instantiate(bulletPrefab, firingPoint.position, Quaternion.identity);
    }

    // void OnDrawGizmosSelected(){
    //     Gizmos.color = Color.green;
    //     Vector3 direction = transform.TransformDirection(Vector2.right) * lineOfSight;
    //     Gizmos.DrawRay(transform.position, direction);
    // }

    private void OnTriggerEnter2D (Collider2D collider){
        if (melee && !ranged && !support){
            if (collider.gameObject.tag == "Piscinoid"){
                animator.SetBool("Piscinoid", true);
            }
        }
    }

    private void OnTriggerExit2D (Collider2D collider){
        if (melee && !ranged && !support){
            if (collider.gameObject.tag == "Piscinoid"){
                animator.SetBool("Piscinoid", false);
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
        animator.SetInteger("Health", health);
	}

    public int ReturnHealth(){
		return health;
	}

    private void Die(){
		Destroy(gameObject);
        return;
	}
}
