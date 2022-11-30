using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class BackgroundMusicScript : MonoBehaviour
{

    public static BackgroundMusicScript instance;
    public AudioSource MenuMusic;
    public AudioSource GameMusic;
    public AudioSource PlayerEngine;
    public AudioSource PlayerFire;
    public AudioSource ShellRicochet;
    public Slider MusicSlider;
    public int MusicVolumeInt;
    public Slider SFXSlider;
    public int SFXVolumeInt;

    // Invoked when the value of the slider changes.
    public void ValueChangeCheck()
    {
        if (SceneManager.GetActiveScene().name == "OptionsMenu")
        {
            //Debug.Log(MusicSlider.value);
            MenuMusic.volume = MusicSlider.value;
            GameMusic.volume = MusicSlider.value;
            PlayerEngine.volume = SFXSlider.value;
            PlayerFire.volume = SFXSlider.value;
            ShellRicochet.volume = SFXSlider.value;
        }
    }

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);

        if (instance == null)
        {
        instance = this;
        }
        else
        {
        Destroy(gameObject);
        }
    }
    private void Update()
    {
        if (SceneManager.GetActiveScene().name == "Menu")
        {
            MenuMusic.UnPause();
            GameMusic.Pause();
        }
        if (SceneManager.GetActiveScene().name == "OptionsMenu")
        {
            MusicSlider = GameObject.Find("MusicSlider").GetComponent<Slider>();
            MusicSlider.onValueChanged.AddListener(delegate { ValueChangeCheck(); });
            SFXSlider = GameObject.Find("SFXSlider").GetComponent<Slider>();
            SFXSlider.onValueChanged.AddListener(delegate { ValueChangeCheck(); });
            MenuMusic.UnPause();
            GameMusic.Pause();
        }
        if (SceneManager.GetActiveScene().name == "LevelSelector")
        {
            MenuMusic.UnPause();
            GameMusic.Pause();
        }

        if (SceneManager.GetActiveScene().name == "TargetTutorial")
        {
            MenuMusic.Pause();
            GameMusic.UnPause();
        }
        if (SceneManager.GetActiveScene().name == "Grasslands")
        {
            MenuMusic.Pause();
            GameMusic.UnPause();
        }
        if (SceneManager.GetActiveScene().name == "Desert")
        {
            MenuMusic.Pause();
            GameMusic.UnPause();
        }
        if (SceneManager.GetActiveScene().name == "Artic")
        {
            MenuMusic.Pause();
            GameMusic.UnPause();
        }
    }
}
