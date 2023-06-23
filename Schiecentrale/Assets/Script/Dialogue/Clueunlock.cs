using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clueunlock : MonoBehaviour
{
    [SerializeField] private TextAsset inkJSON;
    // niet veranderen
    private int NPCid = 0;

    // trigger de unlock text voor een gevonde clue
    public void triggertext()
    {
        Dialoguemanager.Getinstance().EnterDialogueMode(inkJSON, NPCid, null);
    }
}
