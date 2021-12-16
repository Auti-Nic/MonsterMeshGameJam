using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectAbleItem : MonoBehaviour
{

    private bool canCollect = false;


    // Start is called before the first frame update
  

    // Update is called once per frame
    void Update()
    {
        if (canCollect)
        {
            if (Input.GetKey("e"))
            {
                //collect gameobject, need to add more object
                this.gameObject.SetActive(false);
            }
        }
    }

    public void CanCollect()
    {
        this.canCollect = true;
    }

    public void CannotCollect()
    {
        this.canCollect = false;
    }
}
