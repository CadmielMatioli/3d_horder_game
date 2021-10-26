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
    public Animator anim;

    public int AttackTrigger;
    public Slider vidaPlayer;
    public GameObject player;
    private float distance;
    // Start is called before the first frame update
    void Start()
    {
        SoldierDestnavMesh = GetComponent<NavMeshAgent>();
        distance = 0;
    }

    // Update is called once per frame
    void Update()
    {
        /*Player morrendo*/
        StartCoroutine(CounterLife());
        SoldierDestnavMesh.SetDestination(SoldierDest.transform.position);
        distance = Vector3.Distance(stalkerEnemy.transform.position, player.transform.position);
        Debug.Log(distance);
        if (distance <= 5)
        {
            anim.Play("Attack");

        }
        else
        {
            anim.Play("Run");

        }

        //StartCoroutine(AttackAnimation());

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
            if(vidaPlayer.value == 0)
            {
                player.GetComponent<Animator>().Play("dying");
            }
        }
    }

    void OnTriggerExit()
    {
        Debug.Log("teste1");

        AttackTrigger = 0;
    }

    IEnumerator CounterLife() 
    {
        if(vidaPlayer.value == 0)
        {
            yield return new WaitForSeconds(4);
            player.SetActive(false);
            //SceneManager.LoadScene("Nome da cena");
        }

    }
}