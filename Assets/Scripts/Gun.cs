using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public int damage;
    public float range;
    public Camera mainCamera;
    public Camera bulletCamera;
    public GameObject player;
    public ParticleSystem fireShot;
    public ParticleSystem bloodShot;
    public ParticleSystem bloodShot2;
    public AudioSource soundShot;
    public float fireRate = 0.5f;
    private float nextFire = 0.5f;
    public Animator playerAnim;
    public float speed = 100f;

    public float bulletSpeed = -10;
    //public GameObject bullet;
    public Rigidbody bullet;

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
        Rigidbody bulletClone = (Rigidbody)Instantiate(bullet, bulletCamera.transform.position, transform.rotation);
        bulletClone.velocity = mainCamera.transform.forward  * bulletSpeed;
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