using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Hostage : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag != "Rescue")
        {
            //SceneManager.LoadScene("Win");
            Debug.Log("Salvou");
        }
        //if (collider.tag == "Bullet")
        //{
        //    zombieLife.value--;
        //    if (zombieLife.value == 0)
        //    {
        //        anim.Play("dying");
        //        Debug.Log(anim);
        //    }
        //    bloodShot.Play();
        //}
        //else
        //{
        //    bloodShot.Stop();
        //}
    }

    //void OnTriggerExit()
    //{
    //    AttackTrigger = 0;
    //}

    //IEnumerator CounterLife()
    //{
    //    if (zombieLife.value == 0)
    //    {
    //        yield return new WaitForSeconds(4);
    //        Destroy(stalkerEnemy);
    //    }

    //}
}
