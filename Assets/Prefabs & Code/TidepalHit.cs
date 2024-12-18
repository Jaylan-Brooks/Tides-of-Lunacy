using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TidepalHit : MonoBehaviour
{
    [SerializeField] private int damage;

    private void OnTriggerEnter2D (Collider2D collider){
        if (collider.gameObject.tag == "Piscinoid"){
            collider.gameObject.GetComponent<PiscinoidMind>().TakeDamage(damage);
        }
    }
}
