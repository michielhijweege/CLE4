using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialoguetrigger : MonoBehaviour
{
    [SerializeField] private TextAsset inkJSON;
    // elke npc heeft zijn eigen id dit id bepaalt bij wie dit gesprek komt in het log boek
    public int NPCid;

    // trigger de dialogue systeem
    public void triggertext()
    {
        GameObject myEventSystem = GameObject.Find("EventSystem");
        myEventSystem.GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(null);
        Dialoguemanager.Getinstance().EnterDialogueMode(inkJSON, NPCid, this.gameObject);
        this.gameObject.SetActive(false);
    }
}
