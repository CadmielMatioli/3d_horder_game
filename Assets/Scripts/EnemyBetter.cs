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
    private bool triggerOnAwake = false;
    private Animator anim;
    public int AttackTrigger;
    public GameObject player;
    private float distance;
    public ParticleSystem bloodShot;
    public Slider zombieLife;
    // Start is called before the first frame update
    void Start()
    {
        SoldierDestnavMesh = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();

        distance = 0;
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(CounterLife());
        if (triggerOnAwake)
        {
            SoldierDestnavMesh.SetDestination(SoldierDest.transform.position);
        }
        distance = Vector3.Distance(stalkerEnemy.transform.position, player.transform.position);
        if (distance <= 5)
        {
            anim.Play("Attack");
            anim.SetBool("attack", true);
        }
        else
        {
            anim.SetBool("attack", false);
            anim.Play("Run");
        }
    }
    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Seguir")
        {
            triggerOnAwake = true;
        }
        if (collider.tag == "Bullet")
        {
            zombieLife.value--;
            if (zombieLife.value == 0)
            {
                anim.Play("dying");
            }
            bloodShot.Play();
        }
        else
        {
            bloodShot.Stop();
        }
    }

    void OnTriggerExit()
    {
        AttackTrigger = 0;
        SoldierDestnavMesh.SetDestination(transform.position);

    }

    IEnumerator CounterLife() 
    {
        if(zombieLife.value == 0)
        {
            yield return new WaitForSeconds(4);
            Destroy(stalkerEnemy);
        }

    }
}