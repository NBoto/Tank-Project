using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class BackgroundMusicScript : MonoBehaviour
{

    public static BackgroundMusicScript instance;
    public AudioSource MenuMusic; // 'Theme Menu' https://opengameart.org/content/theme-menu
    public AudioSource GameMusic; // 'Battle in the winter' https://opengameart.org/content/battle-in-the-winter
    public AudioSource DefeatStinger; // 'Lose theme' https://opengameart.org/content/lose-music-1
    //public AudioSource VictoryStinger;
    public AudioSource PlayerEngine; // 'Tank' https://soundbible.com/1325-Tank.html
    public AudioSource PlayerFire; // 'Rumble' https://opengameart.org/content/rumbleexplosion
    public AudioSource ShellRicochet; // 'Blop' https://soundbible.com/2067-Blop.html
    //public AudioSource ShellExplosion; // 'Explosion' https://opengameart.org/content/big-explosion   <-- Attached to the Explosion GameObject instead.
    public AudioSource EnemyEngine;
    public AudioSource EnemyFire;
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
            DefeatStinger.volume = MusicSlider.value;
            //VictoryStinger.volume = MusicSlider.value;
            PlayerEngine.volume = SFXSlider.value;
            PlayerFire.volume = SFXSlider.value;
            EnemyEngine.volume = SFXSlider.value;
            EnemyFire.volume = SFXSlider.value;
            ShellRicochet.volume = SFXSlider.value;
            //ShellExplosion.volume = SFXSlider.value;
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
        ///MENU MUSIC///
        if (SceneManager.GetActiveScene().name == "Menu")
        {
            MenuMusic.UnPause();
            GameMusic.Pause();
            if (!DefeatStinger.isPlaying)
            {
                DefeatStinger.Stop();
            }
        }
        if (SceneManager.GetActiveScene().name == "OptionsMenu")
        {
            MusicSlider = GameObject.Find("MusicSlider").GetComponent<Slider>();
            MusicSlider.onValueChanged.AddListener(delegate { ValueChangeCheck(); });
            SFXSlider = GameObject.Find("SFXSlider").GetComponent<Slider>();
            SFXSlider.onValueChanged.AddListener(delegate { ValueChangeCheck(); });
            MenuMusic.UnPause();
            GameMusic.Pause();
            if (!DefeatStinger.isPlaying)
            {
                DefeatStinger.Stop();
            }
        }
        if (SceneManager.GetActiveScene().name == "LevelSelector")
        {
            MenuMusic.UnPause();
            GameMusic.Pause();
        }

        ///GAMEPLAY MUSIC///
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

        ///DEFEAT/VICTORY MUSIC///
        if (SceneManager.GetActiveScene().name == "DestroyedScene")
        {
            MenuMusic.Pause();
            GameMusic.Pause();
            if (!DefeatStinger.isPlaying)
            {
                DefeatStinger.Play();
            }
        }
        if (SceneManager.GetActiveScene().name == "VictoryScene")
        {
            MenuMusic.UnPause();
            GameMusic.Pause();
        }
    }
}
