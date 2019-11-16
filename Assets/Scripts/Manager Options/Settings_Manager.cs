using System.Collections;
using System.IO;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Settings_Manager : MonoBehaviour
{
    public Toggle fullscreenToggle;
    public Dropdown textureQuanlityDropdown;
    public Dropdown resolutionDropdown;
    public Slider musicVolumeSlider;
    public Setting settings;
    public AudioSource musicSource;
    public Button btnApply;
    public Button btnBack;
    public Resolution[] resolutions;

    private void OnEnable()
    {
        settings = new Setting();

        fullscreenToggle.onValueChanged.AddListener(delegate { OnFullscreenToggle(); });
        resolutionDropdown.onValueChanged.AddListener(delegate { OnResolutionChange(); });
        textureQuanlityDropdown.onValueChanged.AddListener(delegate { OntextureQuanlityChange(); });
        musicVolumeSlider.onValueChanged.AddListener(delegate { OnMusicVolumeChange(); });
        btnApply.onClick.AddListener(delegate { OnButtonApply(); });
        btnBack.onClick.AddListener(delegate { OnButtonBack(); });

        resolutions = Screen.resolutions;
        foreach (Resolution resolution in resolutions)
        {
            resolutionDropdown.options.Add(new Dropdown.OptionData(resolution.ToString()));
        }
        LoadSetting();

    }
    public void OnFullscreenToggle()
    {
        settings.fullscreen = Screen.fullScreen = fullscreenToggle.isOn;
    }
    public void OnResolutionChange()
    {
        Screen.SetResolution(resolutions[resolutionDropdown.value].width, resolutions[resolutionDropdown.value].height, Screen.fullScreen);
        settings.resolutionIndex = resolutionDropdown.value;
    }
    public void OntextureQuanlityChange()
    {
        QualitySettings.masterTextureLimit = settings.texttureQuanlity = textureQuanlityDropdown.value;
    }
    public void OnMusicVolumeChange()
    {
        musicSource.volume = settings.musicVolume = musicVolumeSlider.value;
    }
    public void SaveSetting()
    {
        
        string jsonData = JsonUtility.ToJson(settings, true);
        File.WriteAllText(Application.persistentDataPath + "/gamesettings.json", jsonData);
    }
    public void LoadSetting()
    {
        if (File.Exists(Application.persistentDataPath + "/gamesettings.json"))
        {
            settings = JsonUtility.FromJson<Setting>(File.ReadAllText(Application.persistentDataPath + "/gamesettings.json"));
            musicVolumeSlider.value = settings.musicVolume;
            textureQuanlityDropdown.value = settings.texttureQuanlity;
            resolutionDropdown.value = settings.resolutionIndex;
            fullscreenToggle.isOn = settings.fullscreen;
            Screen.fullScreen = settings.fullscreen;
            resolutionDropdown.RefreshShownValue();
        }
        else
        {
            settings = new Setting();
        }
    }
    public void OnButtonApply()
    {
        SaveSetting();
    }
    public void OnButtonBack()
    {
        SceneManager.LoadScene(0);
    }
}


