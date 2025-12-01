using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public static AudioController instance;

    [SerializeField] private AudioSource effects = default;
    [SerializeField] private AudioSource music = default;

    [Header("Effects")]
    [SerializeField] private AudioClip click = default;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        music.Play();
    }
    
    public void PlayEffectClick()
    {
        effects.pitch = Random.Range(0.8f, 1.2f);
        effects.PlayOneShot(click);
    }

    public void StopMusic()
    {
        music.Stop();
    }

    public void PlayMusic()
    {
        music.Play();
    }
}
