using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    public const string MUSIC_KEY = "musicVolume";
    public const string UISFX_KEY = "uisfxVolume";
    public const string SFX_KEY = "sfxVolume";

    [SerializeField] AudioMixer mixer;

    void Awake(){
        LoadVolume();
    }

    void LoadVolume(){ //volume save in AudioSettings.cs

        float musicVolume = PlayerPrefs.GetFloat(MUSIC_KEY, 1f);
        float uisfxVolume = PlayerPrefs.GetFloat(UISFX_KEY, 1f);
        float sfxVolume = PlayerPrefs.GetFloat(SFX_KEY, 1f);
        
        mixer.SetFloat(AudioSettings.MIXER_MUSIC, Mathf.Log10(musicVolume) * 20);
        mixer.SetFloat(AudioSettings.MIXER_UISFX, Mathf.Log10(musicVolume) * 20);
        mixer.SetFloat(AudioSettings.MIXER_SFX, Mathf.Log10(musicVolume) * 20);
    }
}
