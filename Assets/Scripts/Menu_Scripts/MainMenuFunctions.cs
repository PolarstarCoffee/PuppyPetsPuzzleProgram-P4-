using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenuFunctions : MonoBehaviour
{
    public void PlayGame () //Begins the game by cycling throught our build index
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void EndGame () // Ends the game (frfr)
    {
        Application.Quit();
    }

    public void Tutorial () //Tutorial button 
    {
        SceneManager.LoadScene("Tutorial_Scene1");
    }

    






}
