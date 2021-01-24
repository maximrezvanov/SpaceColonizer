using UnityEngine.Audio;
using UnityEngine;
using UnityEngine.UI;


public class Settings : MonoBehaviour
{
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider fxSlider;
   //public AudioMixerGroup mixer;



    void Start()
    {
        musicSlider.value = SoundManager.musicLevel;
        fxSlider.value = SoundManager.fxLevel;
    }


    void Update()
    {
        SoundManager.musicLevel = musicSlider.value;
        SoundManager.fxLevel = fxSlider.value;
    }

  
}
