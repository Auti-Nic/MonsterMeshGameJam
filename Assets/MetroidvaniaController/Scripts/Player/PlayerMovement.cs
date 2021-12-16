using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	public CharacterController2D controller;
	public Animator animator;
	public Rigidbody2D rb;
	public SpriteRenderer sr;

	public float runSpeed = 40f;

	float horizontalMove = 0f;
	bool jump = false;
	bool dash = false;

	public bool isHidden = false;

	//bool dashAxis = false;
	
	// Update is called once per frame
	void Update () {

		if (isHidden)
        {
			rb.constraints = RigidbodyConstraints2D.FreezeAll;
			sr.enabled = false;
		}
        else
        {
			sr.enabled = true;
			rb.constraints = RigidbodyConstraints2D.None;
			rb.constraints = RigidbodyConstraints2D.FreezeRotation;
		}


		horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

		animator.SetFloat("Speed", Mathf.Abs(horizontalMove));


		/*
        if (isHidden)
        {
			if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown("w"))
            {
				isHidden = false;
            }
		}*/

		/*if (Input.GetKeyDown(KeyCode.Z))
		{
			jump = true;
		}

		if (Input.GetKeyDown(KeyCode.C))
		{
			dash = true;
		}*/

		/*if (Input.GetAxisRaw("Dash") == 1 || Input.GetAxisRaw("Dash") == -1) //RT in Unity 2017 = -1, RT in Unity 2019 = 1
		{
			if (dashAxis == false)
			{
				dashAxis = true;
				dash = true;
			}
		}
		else
		{
			dashAxis = false;
		}
		*/

	}

	public void OnFall()
	{
		animator.SetBool("IsJumping", true);
	}

	public void OnLanding()
	{
		animator.SetBool("IsJumping", false);
	}

	void FixedUpdate ()
	{
		// Move our character
		controller.Move(horizontalMove * Time.fixedDeltaTime, jump, dash);
		jump = false;
		dash = false;
	}
}
