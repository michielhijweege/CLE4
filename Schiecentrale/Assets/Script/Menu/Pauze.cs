using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pauze : MonoBehaviour
{
    [SerializeField] GameObject pauzeui;
    [SerializeField] GameObject gameui;
    [SerializeField] Button button;
    private bool ispauze = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pauzeswitch();
        }
    }

    public void pauzeswitch()
    {
        ispauze = !ispauze;
        if (ispauze)
        {
            pauzeui.SetActive(true);
            gameui.SetActive(false);
            Time.timeScale = 0f;
        }
        else
        {
            if (button.ismenu == false)
            {
                button.menuswitch();
            }
            pauzeui.SetActive(false);
            gameui.SetActive(true);
            Time.timeScale = 1f;
        }
    }
}
