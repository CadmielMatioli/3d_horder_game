using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    // private GameObject player;
    NavMeshAgent SoldierDestnavMesh;
    public GameObject SoldierDest;
    public GameObject stalkerEnemy;
    public Animator anim;
    void Start()
    {
        SoldierDestnavMesh = GetComponent<NavMeshAgent> ();
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetFloat("InputMagnitudeZ", -1);
        anim.SetFloat("InputMagnitudeX", 0);

        SoldierDestnavMesh.SetDestination(SoldierDest.transform.position); 
        // stalkerEnemy.GetComponent<Animator>().Play("Run");
    }
}
