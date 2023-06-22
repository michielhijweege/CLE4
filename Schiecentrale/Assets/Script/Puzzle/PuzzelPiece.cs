using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzelPiece : MonoBehaviour
{
    public bool follow;
    [SerializeField] private Puzzel Puzzel;
    public int nummber;

    // Update is called once per frame
    void Update()
    {
        follow = Puzzel.follow[nummber];
        if (follow)
        {
            transform.position = Input.mousePosition;
            if (Input.GetKeyDown(KeyCode.R))
            {
                this.gameObject.transform.rotation = this.gameObject.transform.rotation * Quaternion.Euler(0, 0, 45.0f);
            }
        }
    }

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
