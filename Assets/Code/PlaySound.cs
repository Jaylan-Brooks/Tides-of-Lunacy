using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySound : MonoBehaviour
{
    [Header ("References")]
    [SerializeField] private Transform soundManager;

    [Header ("Attributes")]
    [SerializeField] private string soundEffect;

    private void Sound(){
        soundManager.gameObject.GetComponent<AudioManager>().Play(soundEffect);
    }
}
