using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzelPiece : MonoBehaviour
{
    public bool follow;
    [SerializeField] private Puzzel Puzzel;
    public int nummber;

    public int rotationnumber;

    // zorg dat je het kan oppakken en draaien
    void Update()
    {
        follow = Puzzel.follow[nummber];
        if (follow)
        {
            transform.position = Input.mousePosition;
            if (Input.GetKeyDown(KeyCode.R))
            {
                this.gameObject.transform.rotation = this.gameObject.transform.rotation * Quaternion.Euler(0, 0, 45);
                if(rotationnumber == 7)
                {
                    rotationnumber = 0;
                }
                else
                {
                    rotationnumber++;
                }
            }
        }
    }

    // zorg dat niks anders tegelijk op kan worden gepakt
    public void switchstate()
    {
        if(Puzzel.follow[nummber] == false)
        {
            Puzzel.clearall();
            Puzzel.follow[nummber] = true;
        }
        else
        {
            Puzzel.follow[nummber] = false;
        }
    }
}
