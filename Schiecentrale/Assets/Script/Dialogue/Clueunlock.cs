using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clueunlock : MonoBehaviour
{
    [SerializeField] private TextAsset inkJSON;
    private int NPCid = 0;

    public void triggertext()
    {
        Dialoguemanager.Getinstance().EnterDialogueMode(inkJSON, NPCid, null);
    }
}
