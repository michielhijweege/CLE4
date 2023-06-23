using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Inventory : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] Animator Animator;
    public bool canopen = true;

    [SerializeField] private Image thisimage;

    [SerializeField] GameObject bigimg;

    [SerializeField] List<GameObject> inventoryslots;
    [SerializeField] List<Sprite> allsprites;

    // speel de open animation
    public void OnPointerEnter(PointerEventData eventData)
    {
        if(canopen == true)
        {
            Animator.SetBool("Active", true);
        }
    }

    // speel de close animation
    public void OnPointerExit(PointerEventData eventData)
    {
        if (canopen == true)
        {
            Animator.SetBool("Active", false);
        }
    }

    // kijk of je de inventory mag opennen 
    private void Update()
    {
        if (canopen == false)
        {
            Animator.SetBool("Active", false);
            thisimage.raycastTarget = false;
        }
        if (canopen == true)
        {
            thisimage.raycastTarget = true;
        }
    }

    // maak alle inventory vakjes leeg en zet ze uit
    private void Start()
    {
        inventoryslots[1].GetComponent<Image>().sprite = allsprites[0];
        inventoryslots[2].GetComponent<Image>().sprite = allsprites[0];
        inventoryslots[3].GetComponent<Image>().sprite = allsprites[0];
        inventoryslots[1].SetActive(false);
        inventoryslots[2].SetActive(false);
        inventoryslots[3].SetActive(false);
    }

    // show de foto over het hele scherm
    public void showbigimg()
    {
        bigimg.SetActive(true);
    }

    // sluit de foto
    public void hidebigimg()
    {
        bigimg.SetActive(false);
    }


    // unlock item's en zet de goede foto in het vakje
    public void unlockfoto()
    {
        Debug.Log("unlock foto");
        inventoryslots[1].GetComponent<Image>().sprite = allsprites[2];
        inventoryslots[1].SetActive(true);
    }

    public void unlockkey()
    {
        Debug.Log("unlock key");
        inventoryslots[2].GetComponent<Image>().sprite = allsprites[3];
        inventoryslots[2].SetActive(true);
    }
}
