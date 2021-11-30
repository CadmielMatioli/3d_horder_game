using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Note : MonoBehaviour
{
    public Image noteImage;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Rescue")
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                noteImage.enabled = true;
            }
            if (Input.GetKeyUp(KeyCode.F))
            {
                noteImage.enabled = false;
            }
        }

    }
    void OnTriggerExit(Collider collider)
    {
        if (collider.tag == "Rescue")
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                noteImage.enabled = false;
            }
        }
    }
}
