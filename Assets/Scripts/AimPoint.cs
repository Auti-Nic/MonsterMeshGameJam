using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimPoint : MonoBehaviour
{

    
    // Update is called once per frame
    void Update()
    {
        // Transforms the object's (player) position to a 2D-screen position
        Vector2 playerPos = transform.position;
        // Gets the position of the mouse
        Vector2 mousePos = Input.mousePosition;
        // Creates a vector going from the position of the player to the position of the mouse (in 2D space), and normalizes it
        Vector2 vector = (mousePos - playerPos);

        this.gameObject.GetComponent<FieldOfView>().SetAimDirection(vector);
        
    }
}
