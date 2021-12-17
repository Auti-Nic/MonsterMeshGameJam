using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    public float moveSpeed;

    bool isMoving = true;

    private Vector3 startingPos;

    //Determine how far in each direction the AI will patrol from its starting position
    public float maxRightDistance;
    public float maxLeftDistance;

    PlayerMovement pm;

    private void Start()
    {
        pm = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        startingPos = transform.position;
    }

    private void Update()
    {
        if (pm.isHidden)
            isMoving = true;

        if(transform.position.x - startingPos.x >= maxRightDistance)
        {
            transform.eulerAngles = new Vector3(0, -180, 0);
        }
        else if(transform.position.x - startingPos.x <= -maxLeftDistance)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }

        if(isMoving)
        transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            if(!pm.isHidden)
            isMoving = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            isMoving = true;
        }
    }


}
