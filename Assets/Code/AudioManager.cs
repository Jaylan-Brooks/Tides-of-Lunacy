using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;
    public bool muted;
    // Start is called before the first frame update
    void Awake()
    {
        foreach (Sound s in sounds){
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    public void Play(string name){
        if(!muted){
            Sound s = Array.Find(sounds, sound => sound.name == name);
            if (s == null){
                return;
            }
            s.source.Play();  
        }
    }

    public void Mute(){
        if (muted){
            muted = false;
        }
        else {
            muted = true;
        }
    }
}
