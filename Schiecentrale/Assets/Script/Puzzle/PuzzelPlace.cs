using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzelPlace : MonoBehaviour
{
    [SerializeField] private Puzzel Puzzel;
    [SerializeField] private int nummber;

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.GetComponent<PuzzelPiece>())
        {
            if (collision.collider.GetComponent<PuzzelPiece>().nummber == nummber)
            {
                Puzzel.correctplace[nummber] = true;
                Puzzel.correctplaceint += 1;
                Puzzel.check();
            }
        }
    }

    public void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.GetComponent<PuzzelPiece>())
        {
            if (collision.collider.GetComponent<PuzzelPiece>().nummber == nummber)
            {
                Puzzel.correctplace[nummber] = false;
                Puzzel.correctplaceint -= 1;
            }
        }
    }
}
