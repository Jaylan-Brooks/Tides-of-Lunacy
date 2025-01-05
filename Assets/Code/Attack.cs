using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    [Header ("References")]
    [SerializeField] private Rigidbody2D rb;

    [Header ("Attributes")]
    [SerializeField] private float speed;
    [SerializeField] private int damage;

    private float despawnTimer;

    void Start(){
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(speed, 0);
    }

    void FixedUpdate()
    {
        despawnTimer += Time.deltaTime;
        if (despawnTimer > 1f){
            Break();
        }
    }

    private void OnTriggerEnter2D (Collider2D collider){
        if (collider.gameObject.tag == "Tidepal"){
            collider.gameObject.GetComponent<TidepalMind>().TakeDamage(damage);
            Break();
        }
    }

    private void Break(){
		Destroy(gameObject);
        return;
	}
}
