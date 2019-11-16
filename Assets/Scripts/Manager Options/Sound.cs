using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Sound : MonoBehaviour {
    public Setting settings;
    public AudioSource audioSource;
    public void OnEnable()
    {
        settings = new Setting();
        loadSound();
    }
    public void loadSound()
    {
        settings = JsonUtility.FromJson<Setting>(File.ReadAllText(Application.persistentDataPath + "/gamesettings.json"));
        audioSource.volume = settings.musicVolume;
    }
    /*void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("music");
        if (objs.Length > 1)
            Destroy(this.gameObject);
        DontDestroyOnLoad(this.gameObject);
    }*/
}
