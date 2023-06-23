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

    [SerializeField] List<Image> inventoryslots;
    [SerializeField] List<Sprite> allsprites;

    public void OnPointerEnter(PointerEventData eventData)
    {
        if(canopen == true)
        {
            Animator.SetBool("Active", true);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (canopen == true)
        {
            Animator.SetBool("Active", false);
        }
    }

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

    private void Start()
    {
        inventoryslots[1].sprite = allsprites[0];
        inventoryslots[2].sprite = allsprites[0];
        inventoryslots[3].sprite = allsprites[0];
    }

    public void unlockfoto()
    {
        Debug.Log("unlock foto");
        inventoryslots[1].sprite = allsprites[2];
    }

    public void unlockkey()
    {
        Debug.Log("unlock key");
        inventoryslots[2].sprite = allsprites[3];
    }
}
