using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public List<AudioClip> AudioclipsBackground = new List<AudioClip>();
    public AudioClip AudioclipToSpawn;

    public AudioSource AudioPlayerBackground;
    public AudioSource AudioPlayerSpawner;

    public bool shouldPlay = true;
    // Start is called before the first frame update
    void Start()
    {
        AudioPlayerBackground = GetComponent<AudioSource>();

    }

    public void Update()
    {
        if (!AudioPlayerBackground.isPlaying)
        {
            ShuffleBackgroundAudio();
        }
        else
        { 
            Debug.Log("I am playing");
        }
    }

    public void ShuffleBackgroundAudio()
    {
        int index = (int)Random.Range(0, AudioclipsBackground.Count);
        Debug.Log(index);
        AudioPlayerBackground.clip = AudioclipsBackground[index];
        AudioPlayerBackground.Play();
    }
}
