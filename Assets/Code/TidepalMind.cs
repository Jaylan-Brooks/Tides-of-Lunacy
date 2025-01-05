using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TidepalMind : MonoBehaviour
{
    [Header ("References")]
    [SerializeField] private Animator animator;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform firingPoint;
    [SerializeField] private LayerMask enemyMask;
    [SerializeField] private GameObject deathPop;

    [Header ("Attributes")]
    [SerializeField] private bool ranged;
    [SerializeField] private bool melee;
    [SerializeField] private bool bomb;
    [SerializeField] private bool support;
    [SerializeField] private int health;
    [SerializeField] private string soundEffect;
    [SerializeField] private float lineOfSight;

    void Start(){
        animator = GetComponent<Animator>();
        if ((!ranged && !melee && !bomb) || (ranged && melee) || (ranged && bomb) || (melee && bomb) || (support && (ranged || melee || bomb))){
            support = true;
            ranged = false;
            melee = false;
            bomb = false;
        }
    }

    void Update(){
        if (ranged && !melee && !bomb && !support){
            SpotPiscinoid();
        }
        if (health <= 0 || (LevelManager.main.IsBossTime() && support)){
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
        if (!bomb){
            LevelManager.main.GetComponent<AudioManager>().Play(soundEffect);
        }
    }

    private void OnTriggerEnter2D (Collider2D collider){
        if (bomb){
            if (collider.gameObject.tag == "Piscinoid"){
                Shoot();
                Die();
            }
        }
        if (melee && !ranged && !support && !bomb){
            if (collider.gameObject.tag == "Piscinoid"){
                animator.SetBool("Piscinoid", true);
            }
        }
    }

    private void OnTriggerExit2D (Collider2D collider){
        if (melee && !ranged && !support && !bomb){
            if (collider.gameObject.tag == "Piscinoid"){
                animator.SetBool("Piscinoid", false);
            }
        }
    }

    public void TakeDamage(int damage){
		health -= damage;
        if(!bomb){
            animator.SetInteger("Health", health);  
        }
	}

    public int ReturnHealth(){
		return health;
	}

    public string GetSoundEffect(){
		return soundEffect;
	}

    private void Die(){
        if (!bomb){
            GameObject burst = Instantiate(deathPop, GetComponent<Transform>().position, Quaternion.identity);   
        }
		Destroy(gameObject);
        return;
	}
}
