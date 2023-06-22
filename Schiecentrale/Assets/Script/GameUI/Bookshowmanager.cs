using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bookshowmanager : MonoBehaviour
{
	public GameObject book;
    public Inventory Inventory;

    public void openbook()
	{
		book.SetActive(true);
        Inventory.canopen = false;

    }

    public void closebook()
	{
		book.SetActive(false);
        Inventory.canopen = true;
    }
}
