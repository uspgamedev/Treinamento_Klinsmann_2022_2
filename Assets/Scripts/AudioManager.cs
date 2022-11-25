using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;
    public static AudioManager instance;
    void Awake()
    {
        if(instance == null){
            instance = this;
        }
        else{
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);

        foreach(Sound s in sounds){
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    void Start(){
        Play("MenuTheme", false);
    }

    public void Play(string name, bool overlapSound){
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if(s == null){
            Debug.LogWarning("Som " + name + " não existe");
            return;
        }
        if(overlapSound || (!overlapSound && !s.source.isPlaying)){
            Debug.Log("Tocando: " + name);
            s.source.Play();
        }     
    }

    public void Pause(string name){
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if(s == null){
            Debug.LogWarning("Som " + name + " não existe");
            return;
        }
        if(s.source.isPlaying) 
            s.source.Pause();
    } 

    public void Stop(string name){
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if(s == null){
            Debug.LogWarning("Som " + name + " não existe");
            return;
        } 
        if(s.source.isPlaying){
            Debug.Log("Parou: " + name);
            s.source.Stop();    
        } 
            
    }    
}
