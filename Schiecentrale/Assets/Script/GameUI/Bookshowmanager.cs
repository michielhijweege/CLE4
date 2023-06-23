using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bookshowmanager : MonoBehaviour
{
	public GameObject book;
    public Inventory Inventory;

    // open de log boek
    public void openbook()
	{
		book.SetActive(true);
        Inventory.canopen = false;

    }

    // sluit de log boek
    public void closebook()
	{
		book.SetActive(false);
        Inventory.canopen = true;
    }
}
