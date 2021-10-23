using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class EnemyBetter : MonoBehaviour
{
    NavMeshAgent SoldierDestnavMesh;
    public GameObject SoldierDest;
    public GameObject stalkerEnemy;
    public float TargetDistance;

    public int AttackTrigger;
    public Slider vidaPlayer;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        SoldierDestnavMesh = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        /*Player morrendo*/
        if(vidaPlayer.value == 0)
        {
            player.SetActive(false);
        }

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
    /*Retirar vida do player*/
    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Player")
        {
            vidaPlayer.value--;
        }
    }

    void OnTriggerExit()
    {
        Debug.Log("teste1");

        AttackTrigger = 0;
    }


}