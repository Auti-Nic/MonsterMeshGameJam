using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTeleport : MonoBehaviour
{
    public Transform targetDestination;
    bool canBeTeleported = false;
    GameObject p;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        canBeTeleported = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        canBeTeleported = false;
    }

    private void Start()
    {
        p = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        if (canBeTeleported)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown("w"))
            {
                Debug.Log("teleporting player");
                p.transform.position = targetDestination.transform.position;
            }
        }
    }

}
