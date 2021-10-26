using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public int damage;
    public float range;
    public Camera mainCamera;
    public ParticleSystem fireShot;
    public ParticleSystem bloodShot;
    public AudioSource soundShot;

    public void OnBeforeTransformParentChanged()
    {
        
    }

    private void Awake()
    {


    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            fireShot.Play();
            soundShot.Play();
            Shoot();
        }
        else
        {
            fireShot.Stop();

        }
    }

    void Shoot()
    {
        
        RaycastHit hit;
        if (Physics.Raycast(mainCamera.transform.position, mainCamera.transform.forward, out hit, range))
        {
            bloodShot.Play();

            Debug.Log("Acertou" + hit.transform.name);
        }
        else
        {
            bloodShot.Stop();

        }
    }

     void OnGUI()
    {
        GUI.Label(new Rect(Screen.width/2,Screen.height/2,100,20), "+");
    }
}