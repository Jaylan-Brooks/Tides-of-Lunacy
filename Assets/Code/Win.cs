using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Win : MonoBehaviour
{
    private void OnTriggerEnter2D (Collider2D collider){
        if (collider.gameObject.tag == "Piscinoid"){
            SceneManager.LoadScene("Win Screen");
        }
    }
}
