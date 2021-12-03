using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Note : MonoBehaviour
{
    public Image noteImage;
    public Text hsLabel;
    void Start()
    {
        if (noteImage)
        {
            noteImage.GetComponent<Image>().enabled = false;
        }
        if (hsLabel)
        {
            hsLabel.GetComponent<Text>().enabled = false;
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        if (!collider.CompareTag("Rescue"))
        {
            if (noteImage)
            {
                noteImage.GetComponent<Image>().enabled = true;
            }
            if (hsLabel)
            {
                hsLabel.GetComponent<Text>().enabled = true;
            }
        }

    }
    void OnTriggerExit(Collider collider)
    {
        if (!collider.CompareTag("Rescue"))
        {
            if (noteImage)
            {
                noteImage.GetComponent<Image>().enabled = false;
            }
            if (hsLabel)
            {
                hsLabel.GetComponent<Text>().enabled = false;
            }
        }
    }
}
