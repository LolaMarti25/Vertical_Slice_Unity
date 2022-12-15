using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public AudioMixer mixer;

    public Slider sliderMusic;
    //public Slider sliderSonido;
    public void Start()
    {
        mixer.SetFloat("Volume", 0);
    }
    public void OnMusicVolumeUpdate()
    {
        mixer.SetFloat("Volume", sliderMusic.value);
    }

    //public void OnSoundVolumeUpdate()
    //{
    //    effectSource.volume = sliderSonido.value;
    //}

}
