using System;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public GameSound[] gameSounds;

    public static AudioManager instance;

    void Awake()
    {
        if(instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        foreach (GameSound gs in gameSounds)
        {
            gs.source = gameObject.AddComponent<AudioSource>();
            gs.source.clip = gs.clip;
            gs.source.volume = gs.volume;
            gs.source.pitch = gs.pitch;
            gs.source.loop = gs.loop;
        } 
    }

    void Start()
    {
        PlaySound("BackgroundSound");
    }

    public void PlaySound(string name)
    {
        GameSound gs = Array.Find(gameSounds, sound => sound.name == name);
        if (gs == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }
        gs.source.Play();
    }

    public void StopSound(string name)
    {
        GameSound gs = Array.Find(gameSounds, sound => sound.name == name);
        if (gs == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }
        gs.source.Stop();
    }
}
