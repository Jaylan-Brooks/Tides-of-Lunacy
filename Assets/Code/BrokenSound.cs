using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrokenSound : MonoBehaviour
{
    [Header ("References")]
    [SerializeField] private TidepalMind self;

    [Header ("Attributes")]
    [SerializeField] private int brokenHealth;

    void Start(){
        self = GetComponent<TidepalMind>();
    }

    void Update(){
        if (self.ReturnHealth() <= brokenHealth){
            LevelManager.main.GetComponent<AudioManager>().Play(self.GetSoundEffect());
            enabled = false;
        }
    }
}
