using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzel : MonoBehaviour
{
    public List<bool> follow;
    public List<GameObject> pieces;

    [SerializeField] List<GameObject> piecesplace;
    public List<bool> correctplace;
    public int correctplaceint;
    public bool once;
    [SerializeField] private GameObject endresult;
    [SerializeField] private GameObject center;
    private Inventory Inventory;
    [SerializeField] Clueunlock Clueunlock;

    public void clearall()
    {
        for (int i = 0; i < follow.Count; i++)
        {
            follow[i] = false;
        }
    }

    public void Start()
    {
        GameObject Inventorymanager = GameObject.Find("Inventory Trigger");
        Inventory = Inventorymanager.GetComponent<Inventory>();
        Inventory.canopen = false;
    }

    public void check()
    {
        if(correctplaceint == correctplace.Count && !once)
        {
            clearall();
            Debug.Log("done");
            for (int i = 0; i < pieces.Count; i++)
            {
                pieces[i].SetActive(false);
            }
            endresult.transform.position = center.transform.position;
            endresult.SetActive(true);
            once = true;
            Inventory.unlockfoto();
            Clueunlock.triggertext();
            Inventory.canopen = true;
        }
    }
}