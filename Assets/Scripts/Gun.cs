using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{

    public Transform bulletPrefab;

    Animator animator;
    AudioSource audioSource;

    Transform shotSpawn;
    Transform shellSpawn;

    string gunName = "Sniper";

    private void Awake()
    {

        animator = transform.Find("M4A1 Sopmod").GetComponent<Animator>();
        audioSource = transform.GetComponent<AudioSource>();
        shotSpawn = transform.Find("shotSpawn");
        shellSpawn = transform.Find("shellSpawn");

    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {

            animator.Play("Shoot", -1, 0);

            audioSource.Play();


            // implementação do tiro vem aqui....
            // ShootRaycast();
            //ShootBullet();
        }
    }
}