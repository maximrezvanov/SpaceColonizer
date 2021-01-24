using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;


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
    [SerializeField] private AudioMixerGroup mixer;

    public AudioClip flySound;
    public AudioClip boomSound;
    public AudioClip addBonusSound;
    public AudioClip finishSound;

    public static float musicLevel = 0.25f;
    public static float fxLevel = 1.0f;


    void Start()
    {
        audio = GetComponent<AudioSource>();
        //ChangeMusicLevel(musicLevel);
    }

    public void PlaySound(AudioClip clip)
    {
        audio.PlayOneShot(clip);
    }


    private void Update()
    {
        mixer.audioMixer.SetFloat("Music", musicLevel);
        mixer.audioMixer.SetFloat("Effects", fxLevel);

    }

    //public void ChangeMusicLevel(float volume)
    //{
    //    mixer.audioMixer.SetFloat("Music", Mathf.Lerp(-80, 0, volume));
    //    musicLevel = volume;

    //}

    //public void ChangeEffectsLevel(float volume)
    //{
    //    mixer.audioMixer.SetFloat("Effects", Mathf.Lerp(-80, 0, volume));
    //}




}
