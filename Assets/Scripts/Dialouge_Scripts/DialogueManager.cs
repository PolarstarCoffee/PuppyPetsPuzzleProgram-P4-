using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class DialogueManager : MonoBehaviour
    

{
    public GameObject IconSelection;
    public TMP_Text dialogueText; //refrence to display actual text
    private Queue<string> sentences; //FIFO (First in first out data structure) private might need to be changed to public later to use it on other levels (if that's how that works lmao)
    
    //Initalization
    void Start()
    {
      
        sentences = new Queue<string>(); //Initalizes Queue
        IconSelection.SetActive(false);
    }

    public void StartDialogue (Dialogue dialogue) //Begins Dialogue 
    {
        Debug.Log("Starting conversation" + dialogue.name); //Debug for testing 



        sentences.Clear(); //Clears Sentences so new one can load 

        foreach (string sentence in dialogue.sentences) //runs through the queue 
        {
            sentences.Enqueue(sentence); //Loads new Dialogue 
        }

        DisplayNextSentence();// After new Dialogue is loded, it displays the next sentence 
        

       

   
     

       

        
    }
    public void DisplayNextSentence() //Next Sentence 
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        Debug.Log("Ending Conversation");
        dialogueText.text = sentence;
        if (SceneManager.GetActiveScene().name == "Dialouge_1")
        {
            if (sentences.Count == 2) //Once there are 2 sentences left in the queue, the icon will appear within Dialogue scene 1
            {
                IconSelection.SetActive(true);
               
            }

        }

    void EndDialogue() //Signifies the end of the Dialogue 
    {
        Debug.Log("End of Conversation");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
       // if (SceneManager.GetActiveScene().buildIndex == 13) //if the build index is at our tutorial level start level 1
       // {
           // SceneManager.LoadScene("Level01_Prototype");
       // }
       // else
        //{
           // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

       // }
    }
 
    //public void IconPictureReveal()
    {
        

        }
    }

  
}
