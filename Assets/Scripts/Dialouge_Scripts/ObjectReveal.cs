using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ObjectReveal : MonoBehaviour
{
    public GameObject continuebutton;
    public GameObject beginbutton;
    // Start is called before the first frame update
    void Start() //sets the visibility of the buttons 
    {
        continuebutton.SetActive(false);
        beginbutton.SetActive(true);
        
    }


    // Update is called once per frame
    public void onClick() //updates the visibility of the buttons on click
    {
        continuebutton.SetActive(true);
        beginbutton.SetActive(false);
    }
}
