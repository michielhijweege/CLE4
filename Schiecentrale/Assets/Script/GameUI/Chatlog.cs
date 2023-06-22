using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Ink.Runtime;
using UnityEngine.UI;
using TMPro;

public class Chatlog : MonoBehaviour
{
    [SerializeField] RawImage mensinfo;
    [SerializeField] TMP_Text chatmetmens;
    public bool[] kentmensen;
    [SerializeField] int currentmenseninfo;
    [SerializeField] int currentmensenchat;
    public allemenseninfo[] allemenseninfo;
    [SerializeField] TMP_Text menseninfoamount;
    [SerializeField] TMP_Text chatamount;

    public void volgendeinfo()
    {
        //zorgen dat de info loopt naar de eerste pagina
        if (currentmenseninfo == allemenseninfo.Length - 1)
        {
            currentmenseninfo = 1;
        }
        else
        {
            currentmenseninfo++;
        }

        //kijk of dat je deze persoon kent
        if (kentmensen[currentmenseninfo])
        {
            mensinfo.texture = allemenseninfo[currentmenseninfo].mensinfo[1];
            chatmetmens.text = allemenseninfo[currentmenseninfo].inkJSON[1];
            currentmensenchat = 1;
            int amountofchat = allemenseninfo[currentmenseninfo].inkJSON.Count - 1;
            chatamount.text = currentmensenchat.ToString() + " / " + amountofchat.ToString();
        }
        else
        {
            mensinfo.texture = allemenseninfo[currentmenseninfo].mensinfo[0];
            currentmensenchat = 0;
            chatmetmens.text = allemenseninfo[currentmenseninfo].inkJSON[0];
            chatamount.text = "0 / 0";
        }
        int amountofinfo = allemenseninfo.Length - 1;
        menseninfoamount.text = currentmenseninfo.ToString() + " / " + amountofinfo.ToString();
    }

    public void vorigeinfo()
    {
        //zorgen dat de info loopt naar de laatste pagina
        if (currentmenseninfo == 1)
        {
            currentmenseninfo = allemenseninfo.Length - 1;
        }
        else
        {
            currentmenseninfo -= 1;
        }

        //kijk of dat je deze persoon kent
        if (kentmensen[currentmenseninfo])
        {
            mensinfo.texture = allemenseninfo[currentmenseninfo].mensinfo[1];
            chatmetmens.text = allemenseninfo[currentmenseninfo].inkJSON[1];
            currentmensenchat = 1;
            int amountofchat = allemenseninfo[currentmenseninfo].inkJSON.Count - 1;
            chatamount.text = currentmensenchat.ToString() + " / " + amountofchat.ToString();
        }
        else
        {
            mensinfo.texture = allemenseninfo[currentmenseninfo].mensinfo[0];
            currentmensenchat = 0;
            chatmetmens.text = allemenseninfo[currentmenseninfo].inkJSON[0];
            chatamount.text = "0 / 0";
        }
        int amountofinfo = allemenseninfo.Length - 1;
        menseninfoamount.text = currentmenseninfo.ToString() + " / " + amountofinfo.ToString();
    }

    public void volgendechat()
    {
        //zorgen dat de info loopt naar de eerste pagina
        if (currentmensenchat == allemenseninfo[currentmenseninfo].inkJSON.Count - 1)
        {
            currentmensenchat = 1;
        }
        else
        {
            currentmensenchat++;
        }

        if (kentmensen[currentmenseninfo])
        {
            chatmetmens.text = allemenseninfo[currentmenseninfo].inkJSON[currentmensenchat];
            int amountofinfo = allemenseninfo[currentmenseninfo].inkJSON.Count - 1;
            chatamount.text = currentmensenchat.ToString() + " / " + amountofinfo.ToString();
        }
        else
        {
            currentmensenchat = 0;
            chatmetmens.text = allemenseninfo[currentmenseninfo].inkJSON[0];
            chatamount.text = "0 / 0";
        }
    }

    public void vorigechat()
    {
        //zorgen dat de info loopt naar de laatste pagina
        if (currentmensenchat == 1)
        {
            currentmensenchat = allemenseninfo[currentmenseninfo].inkJSON.Count - 1;
        }
        else
        {
            currentmensenchat -= 1;
        }

        if (kentmensen[currentmenseninfo])
        {
            chatmetmens.text = allemenseninfo[currentmenseninfo].inkJSON[currentmensenchat];
            int amountofinfo = allemenseninfo[currentmenseninfo].inkJSON.Count - 1;
            chatamount.text = currentmensenchat.ToString() + " / " + amountofinfo.ToString();
        }
        else
        {
            currentmensenchat = 0;
            chatmetmens.text = allemenseninfo[currentmenseninfo].inkJSON[0];
            chatamount.text = "0 / 0";
        }
    }

    public void Updateinfo(int id)
    {
        if (!kentmensen[id])
        {
            kentmensen[id] = true;
        }
        if (kentmensen[id] == true && currentmenseninfo == id)
        {
            currentmensenchat = 1;
            mensinfo.texture = allemenseninfo[currentmenseninfo].mensinfo[1];

            chatmetmens.text = allemenseninfo[currentmenseninfo].inkJSON[currentmensenchat];
            int amountofinfo = allemenseninfo[currentmenseninfo].inkJSON.Count - 1;
            chatamount.text = currentmensenchat.ToString() + " / " + amountofinfo.ToString();
        }
    }
}

[System.Serializable]
public class allemenseninfo
{
    public List<Texture> mensinfo;
    public List<string> inkJSON;
}