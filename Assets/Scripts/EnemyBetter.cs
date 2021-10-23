using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBetter : MonoBehaviour
{
    NavMeshAgent SoldierDestnavMesh;
    public GameObject SoldierDest;
    public GameObject stalkerEnemy;
    public float TargetDistance;

    public int AttackTrigger;

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
        //stalkerEnemy.GetComponent<Animation>().Play("dying");
        //stalkerEnemy.GetComponent<Animation>().Play("Walk");
        //stalkerEnemy.GetComponent<Animation>().Play("Attak");
        if (AttackTrigger == 1)
        {
            Debug.Log("teste");
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        Debug.Log("teste1");

        AttackTrigger = 1;
    }

    void OnTriggerExit()
    {
        Debug.Log("teste1");

        AttackTrigger = 0;
    }
}