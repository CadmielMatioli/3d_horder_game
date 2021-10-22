using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBetter : MonoBehaviour
{
    NavMeshAgent SoldierDestnavMesh;
    public GameObject SoldierDest;
    public GameObject stalkerEnemy;
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        SoldierDestnavMesh = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        SoldierDestnavMesh.SetDestination(SoldierDest.transform.position);
        stalkerEnemy.GetComponent<Animator>().Play("Run");
    }
}