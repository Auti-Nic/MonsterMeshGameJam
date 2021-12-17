using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HidingCabinet : MonoBehaviour
{
    bool canHide = false;
    GameObject p;
    PlayerMovement pm;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(!pm.isHidden)
        canHide = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        canHide = false;
    }

    private void Start()
    {
        p = GameObject.FindGameObjectWithTag("Player");
        pm = p.GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        if (canHide && !pm.isHidden)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown("w"))
            {
                Debug.Log("hiding player");
                pm.isHidden = true;
                canHide = false;
            }
        }
        else if (pm.isHidden)
        {
            if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown("s"))
            {
                Debug.Log("player exiting cabinet");
                pm.isHidden = false;
                canHide = true;
            }
        }
    }
}
