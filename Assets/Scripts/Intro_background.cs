using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Intro_background : MonoBehaviour {

    public bool check;
    public GameObject menu;
    public Text txtSound;
    public void back_Intro()
    {
        SceneManager.LoadScene(0);
    }
    public void load_scene_play()
    {
        SceneManager.LoadScene(1);
    }
    public void load_scene_option()
    {
        SceneManager.LoadScene(2);
    }
    public void load_about()
    {
        SceneManager.LoadScene(4);
    }
    public void load_quuit()
    {
        SceneManager.LoadScene("End");
    }
}
