using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public Dialogue dialogue; 

    public void InteractableDialogue() //Initiates the actual dialogue  and finds our manager
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue); //Finds our manager using a "Singleton pattern"(complex unity thing, gotta understand what it 100% means)

    }
}
