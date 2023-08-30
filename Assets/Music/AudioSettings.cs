using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioSettings : MonoBehaviour
{
    [SerializeField] AudioMixer mixer;
    [SerializeField] Slider musicSlider;
    [SerializeField] Slider uisfxSlider;
    [SerializeField] Slider sfxSlider;


    public const string MIXER_MUSIC = "MusicVolume";
    public const string MIXER_UISFX = "UISFXVolume";
    public const string MIXER_SFX = "SFXVolume";

    void Awake() {
        musicSlider.onValueChanged.AddListener(SetMusicVolume);
        uisfxSlider.onValueChanged.AddListener(SetUISFXVolume);
        sfxSlider.onValueChanged.AddListener(SetSFXVolume);
    }

    void Start(){
        musicSlider.value = PlayerPrefs.GetFloat(AudioManager.MUSIC_KEY, 1f);
        uisfxSlider.value = PlayerPrefs.GetFloat(AudioManager.UISFX_KEY, 1f);
        sfxSlider.value = PlayerPrefs.GetFloat(AudioManager.SFX_KEY, 1f);
      
    }

    void OnDisable() {
        PlayerPrefs.SetFloat(AudioManager.MUSIC_KEY, musicSlider.value);
        PlayerPrefs.SetFloat(AudioManager.UISFX_KEY, uisfxSlider.value);
        PlayerPrefs.SetFloat(AudioManager.SFX_KEY, sfxSlider.value);
    }

    void SetMusicVolume(float value){
        mixer.SetFloat(MIXER_MUSIC, Mathf.Log10(value) * 20);
    }

    void SetUISFXVolume(float value){
        mixer.SetFloat(MIXER_UISFX, Mathf.Log10(value) * 20);
    }

     void SetSFXVolume(float value){
        mixer.SetFloat(MIXER_SFX, Mathf.Log10(value) * 20);
    }
}