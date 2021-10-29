using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public int damage;
    public float range;
    public Camera mainCamera;
    public GameObject player;
    public ParticleSystem fireShot;
    public ParticleSystem bloodShot;
    public ParticleSystem bloodShot2;
    public AudioSource soundShot;
    public float fireRate = 0.5f;
    private float nextFire = 0.5f;
    public Animator playerAnim;

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
        Soting();
    }

    void Shoot()
    {
        
        RaycastHit hit;
        if (Physics.Raycast(mainCamera.transform.position, mainCamera.transform.forward, out hit, range))
        {
            if(hit.transform.name == "SoldierZombie")
            {
                bloodShot.Play();
            }
            else if(hit.transform.name == "derrick")
            {
                bloodShot2.Play();
            }
            else
            {
                bloodShot.Stop();
                bloodShot2.Stop();
            }
        }

    }

     void OnGUI()
    {
        GUI.Label(new Rect(Screen.width/2,Screen.height/2,100,20), "+");
    }

    void Soting()
    {
        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            playerAnim.SetBool("Fire", true);
            soundShot.Play();
            StartCoroutine(StopFireAnim());
            nextFire = Time.time + fireRate;
            Shoot();
        }
        else
        {
            fireShot.Stop();
        }
        if (!Input.GetButton("Fire1"))
        {
            playerAnim.SetBool("Fire", false);
        }
    }

    IEnumerator StopFireAnim()
    {

        yield return new WaitForSeconds(0.1f);
        fireShot.Play();

    }
}