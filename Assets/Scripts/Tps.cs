using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tps : MonoBehaviour
{

    public Animator anim;
    public GameObject cam;
    public GameObject playerModel;
	float gravity = -9.8f;

	public float speed = 4.5f;
	public float sensitivity = 30.0f;
	public float WaterHeight = 15.5f;

    void Update()
    {

        float camY = cam.transform.rotation.eulerAngles.y;

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

		CheckForWaterHeight ();

        anim.SetFloat("InputMagnitudeZ", z);
        anim.SetFloat("InputMagnitudeX", x);

        if(Input.GetMouseButton(1)){
            playerModel.transform.rotation = Quaternion.Slerp(playerModel.transform.rotation, Quaternion.Euler(0, camY, 0), Time.deltaTime * 100);
            anim.SetBool("IsAiming", true);
            cam.GetComponent<Camera>().fieldOfView = Mathf.Lerp(cam.GetComponent<Camera>().fieldOfView, 30f, 0.5f);
        }else{
            playerModel.transform.rotation = Quaternion.Slerp(playerModel.transform.rotation, Quaternion.Euler(0, camY, 0), Time.deltaTime * 50);
            anim.SetBool("IsAiming", false);
            cam.GetComponent<Camera>().fieldOfView = Mathf.Lerp(cam.GetComponent<Camera>().fieldOfView, 60f, 0.5f);
        }
    }

    	void CheckForWaterHeight(){
		if (transform.position.y < WaterHeight) {
			gravity = 0f;			
		} else {
			gravity = -9.8f;
		}
	}
    
}
