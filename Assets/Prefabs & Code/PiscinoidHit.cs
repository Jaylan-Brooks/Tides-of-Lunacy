using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiscinoidHit : MonoBehaviour
{
    [SerializeField] private int damage;

    private void OnTriggerEnter2D (Collider2D collider){
        if (collider.gameObject.tag == "Tidepal"){
            collider.gameObject.GetComponent<TidepalMind>().TakeDamage(damage);
        }
    }

}

