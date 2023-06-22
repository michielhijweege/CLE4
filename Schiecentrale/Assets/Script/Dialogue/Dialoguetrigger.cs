using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialoguetrigger : MonoBehaviour
{
    [SerializeField] private TextAsset inkJSON;
    public int NPCid;

    public void triggertext()
    {
        GameObject myEventSystem = GameObject.Find("EventSystem");
        myEventSystem.GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(null);
        Dialoguemanager.Getinstance().EnterDialogueMode(inkJSON, NPCid, this.gameObject);
        this.gameObject.SetActive(false);
    }
}
