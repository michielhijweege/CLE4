using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour
{
    public GameObject menuui;
    public GameObject settingui;
    public bool ismenu = true;

    // switch tussen de menu en de setting screen
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

    // start de game op
    public void play()
    {
        SceneManager.LoadScene("Game");
    }

    // sluit de game
    public void quit()
    {
        Application.Quit();
    }
}
