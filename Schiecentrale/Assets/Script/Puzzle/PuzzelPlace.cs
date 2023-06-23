using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzelPlace : MonoBehaviour
{
    [SerializeField] private Puzzel Puzzel;
    [SerializeField] private int nummber;

    // kijk of dat er een puzzel stuk in de correct gebied gaat verder kijk of dat ze op de zelfde anier zijn gedraaid
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.GetComponent<PuzzelPiece>() && collision.collider.GetComponent<PuzzelPiece>().nummber == nummber && collision.collider.GetComponent<PuzzelPiece>().rotationnumber == Puzzel.pieces[0].GetComponent<PuzzelPiece>().rotationnumber)
        {
            Puzzel.correctplace[nummber] = true;
            Puzzel.correctplaceint += 1;
            Puzzel.check();
        }
    }

    // kijk of dat het correcte puzzel stuk op de zelfde rotatie staat en of dat hij niet al als correct hebt gezet en als je de puzzel stuk draai zeg dan dat hij niet meer goed staat
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

    // kijk of dat er een puzzel stuk in uit de correct gebied gaat verder kijk of dat hij niet al verkeert stond
    public void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.GetComponent<PuzzelPiece>() && collision.collider.GetComponent<PuzzelPiece>().nummber == nummber && Puzzel.correctplace[nummber] == true)
        {
            Puzzel.correctplace[nummber] = false;
            Puzzel.correctplaceint -= 1;
        }
    }
}
