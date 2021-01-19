using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    #region Singelton
    public static SoundManager Instance
    {
        get
        {
            return instance;
        }
    }

    private static SoundManager instance = null;

    private void Awake()
    {
        if (instance)
        {
            DestroyImmediate(gameObject);
            return;
        }
        else
            DontDestroyOnLoad(gameObject);

        instance = this;
    }
    #endregion

    private AudioSource audio;

    public AudioClip flySound;
    public AudioClip boomSound;
    public AudioClip addBonusSound;
    public AudioClip finishSound;


    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    void Update()
    {
        
    }


    public void PlaySound(AudioClip clip)
    {
        audio.PlayOneShot(clip);
    }
}
