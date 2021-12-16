using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detector : MonoBehaviour
{
    PlayerDetection pd;

    private void Start()
    {
        pd = GameObject.Find("Player").GetComponent<PlayerDetection>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            Debug.Log("Entered Detector");
            if(pd != null)
                pd.detectors.Add(this);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            Debug.Log("Exited Detector");
            if (pd != null)
                pd.detectors.Remove(this);
        }
    }
}
