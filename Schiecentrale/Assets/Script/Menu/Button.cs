using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour
{
    public GameObject menuui;
    public GameObject settingui;
    public bool ismenu = true;

    public void menuswitch()
    {
        ismenu = !ismenu;
        if (ismenu)
        {
            menuui.SetActive(true);
            settingui.SetActive(false);
        }
        else
        {
            menuui.SetActive(false);
            settingui.SetActive(true);
        }
    }

    public void play()
    {
        SceneManager.LoadScene("Game");
    }

    public void quit()
    {
        Application.Quit();
    }
}
