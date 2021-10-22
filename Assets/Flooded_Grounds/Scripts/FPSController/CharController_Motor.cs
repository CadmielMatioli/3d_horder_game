﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharController_Motor : MonoBehaviour {

	public float speed = 4.5f;
	public float sensitivity = 30.0f;
	public float WaterHeight = 15.5f;
	CharacterController character;
	public GameObject cam;
	float moveFB, moveLR;
	float rotX, rotY;
	public bool webGLRightClickRotation = true;
	float gravity = -9.8f;

	public float jumpForce = 5f;
	private float moveY;
	public Animator anim;

	public float GroundCheckSize;
	public Vector3 GroundCheckPosition;
	public LayerMask LayerMask;

    private void Awake()
    {
		transform.tag = "Player";
	}
    void Start(){
		//LockCursor ();
		character = GetComponent<CharacterController> ();
		if (Application.isEditor) {
			webGLRightClickRotation = false;
			sensitivity = sensitivity * 1.5f;
		}
	}


	void CheckForWaterHeight(){
		if (transform.position.y < WaterHeight) {
			gravity = 0f;			
		} else {
			gravity = -9.8f;
		}
	}



	void Update(){
		if (Input.GetButtonDown("Sprint"))
        {
			Debug.Log(Input.GetButtonDown("Sprint"));
			speed = 9.1f;

        }
        if (Input.GetButtonUp("Sprint")){
			speed = 4.5f;
        }

		moveFB = Input.GetAxis ("Horizontal") * speed;
		moveLR = Input.GetAxis ("Vertical") * speed;

		rotX = Input.GetAxis ("Mouse X") * sensitivity;
		rotY = Input.GetAxis ("Mouse Y") * sensitivity;

		//rotX = Input.GetKey (KeyCode.Joystick1Button4);
		//rotY = Input.GetKey (KeyCode.Joystick1Button5);

		CheckForWaterHeight ();


		Vector3 movement = new Vector3 (moveFB, gravity, moveLR);



		if (webGLRightClickRotation) {
			if (Input.GetKey (KeyCode.Mouse0)) {
				CameraRotation (cam, rotX, rotY);
			}
		} else if (!webGLRightClickRotation) {
			CameraRotation (cam, rotX, rotY);
		}



		var groundCheck = Physics.OverlapSphere(transform.position + GroundCheckPosition, GroundCheckSize, LayerMask);
		if (groundCheck.Length == 0)
        {
			anim.SetBool("Jump", false);
			if (Input.GetButtonDown("Jump"))
			{
				moveY = jumpForce;
				anim.SetBool("Jump", true);
			}
        }
        else
        {
			anim.SetBool("Jump", true);
		}


		moveY += gravity * Time.deltaTime;
		movement.y = moveY;

		movement = transform.rotation * movement;
		character.Move (movement * Time.deltaTime);

       
	}


	void CameraRotation(GameObject cam, float rotX, float rotY){		
		transform.Rotate (0, rotX * Time.deltaTime, 0);
		cam.transform.Rotate (-rotY * Time.deltaTime, 0, 0);
	}




}
