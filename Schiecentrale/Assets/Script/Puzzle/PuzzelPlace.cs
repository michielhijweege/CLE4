using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzelPlace : MonoBehaviour
{
    [SerializeField] private Puzzel Puzzel;
    [SerializeField] private int nummber;

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.GetComponent<PuzzelPiece>() && collision.collider.GetComponent<PuzzelPiece>().nummber == nummber && collision.collider.GetComponent<PuzzelPiece>().rotationnumber == Puzzel.pieces[0].GetComponent<PuzzelPiece>().rotationnumber)
        {
            Puzzel.correctplace[nummber] = true;
            Puzzel.correctplaceint += 1;
            Puzzel.check();
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.collider.GetComponent<PuzzelPiece>().nummber == nummber && collision.collider.GetComponent<PuzzelPiece>().rotationnumber == Puzzel.pieces[0].GetComponent<PuzzelPiece>().rotationnumber && Puzzel.correctplace[nummber] == false)
        {
            Puzzel.correctplace[nummber] = true;
            Puzzel.correctplaceint += 1;
            Puzzel.check();
        }
        if (collision.collider.GetComponent<PuzzelPiece>().nummber == nummber && collision.collider.GetComponent<PuzzelPiece>().rotationnumber != Puzzel.pieces[0].GetComponent<PuzzelPiece>().rotationnumber && Puzzel.correctplace[nummber] == true)
        {
            Puzzel.correctplace[nummber] = false;
            Puzzel.correctplaceint -= 1;
        }
    }

    public void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.GetComponent<PuzzelPiece>() && collision.collider.GetComponent<PuzzelPiece>().nummber == nummber && Puzzel.correctplace[nummber] == true)
        {
            Puzzel.correctplace[nummber] = false;
            Puzzel.correctplaceint -= 1;
        }
    }
}
