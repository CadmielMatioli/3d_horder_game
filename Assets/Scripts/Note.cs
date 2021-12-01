using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Note : MonoBehaviour
{
    public Image noteImage;

    void Start()
    {
        noteImage.GetComponent<Image>().enabled = false;
    }

    void OnTriggerEnter(Collider collider)
    {
        if (!collider.CompareTag("Rescue"))
        {
            noteImage.GetComponent<Image>().enabled = true;
        }

    }
    void OnTriggerExit(Collider collider)
    {
        if (!collider.CompareTag("Rescue"))
        {
            noteImage.GetComponent<Image>().enabled = false;
        }
    }
}
