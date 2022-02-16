using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Objective_Counter : MonoBehaviour
{
    //Variables
    //Test Objective amount
    public int objectiveGoal = 3;
    //int var for counting amount of Icons matched for each type of pet
    public int dogsMatched = 0;
    public int catsMatched = 0;
    public int birdsMatched = 0;
    public int obstaclesMatched = 0;

    //counter for the current level objective
    //public int currentObjective = 0;

    //ref Board.cs to get moveCount and moveLimit
    public GameObject boardObject;
    public Board boardScript;

    //TMP 
    public TextMeshProUGUI objectiveDisplay;

    // Start is called before the first frame update
    void Start()
    {
        //getting a ref to the Board.cs script
        boardObject = GameObject.Find("Board");
        boardScript = boardObject.GetComponent<Board>();

        //first check what levelIndex the Board.cs is on to determine what level objectives are needed
        if (boardScript.levelIndex == 1)
        {
            //
        }

    }

    // Update is called once per frame
    void Update()
    {

        //run the level one objective counters, count bird (type = 0) 
        if (boardScript.levelIndex == 1)
        {
            if (boardScript.matchType == 0)
            {
                birdsMatched += boardScript.matchAmount;
                Debug.Log(birdsMatched + "/" + objectiveGoal + "Birds Matched");

                //reset the matchType, otherwise will infinite add
                boardScript.matchType = -1;
            }

            //check if the level objective has been reached
            if (birdsMatched >= objectiveGoal)
            {
                Debug.Log("Congratulations, you reached the Level Objective");
                //reset birdsMatched counter
                //birdsMatched = 0;
                //go to the win scene/move to the next scene (dialouge or next level or win screen w/ score)
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

            }

            //display the amount of objective matches
            objectiveDisplay.text = birdsMatched + "/" + objectiveGoal + "Birds Matched";
        }



        //level two objective, count obstacles 'cleared'
        if (boardScript.levelIndex == 2)
        {
            if (boardScript.matchType == 2)
            {
                obstaclesMatched += boardScript.matchAmount;
                Debug.Log(obstaclesMatched + "/" + objectiveGoal);

                boardScript.matchType = -1;
            }

            //check if the level objective has been reached
            if (obstaclesMatched >= objectiveGoal)
            {
                Debug.Log("Congratulations, you reached the Level Objective");
                //reset birdsMatched counter
                //birdsMatched = 0;
                //go to the win scene/move to the next scene (dialouge or next level or win screen w/ score)
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

            }

            //display the amount of objective matches
            objectiveDisplay.text = obstaclesMatched + "/" + objectiveGoal + "Yellow Dogs Matched";
        }



        //level three objective, count cats matched (type = 1)
        if (boardScript.levelIndex == 3)
        {
            if (boardScript.matchType == 1)
            {
                catsMatched += boardScript.matchAmount;
                Debug.Log(catsMatched + "/" + objectiveGoal);

                boardScript.matchType = -1;
            }

            //check if the level objective has been reached
            if (catsMatched >= objectiveGoal)
            {
                Debug.Log("Congratulations, you reached the Level Objective");
                //reset birdsMatched counter
                //birdsMatched = 0;
                //go to the win scene/move to the next scene (dialouge or next level or win screen w/ score)
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

            }

            //display the amount of objective matches
            objectiveDisplay.text = catsMatched + "/" + objectiveGoal + "Cats Matched";
        }



        //level four objective, count obstacles 'cleared' (type = 4)
        if (boardScript.levelIndex == 4)
        {
            if (boardScript.matchType == 3)
            {
                obstaclesMatched += boardScript.matchAmount;
                Debug.Log(obstaclesMatched + "/" + objectiveGoal);

                boardScript.matchType = -1;
            }

            //check if the level objective has been reached
            if (obstaclesMatched >= objectiveGoal)
            {
                Debug.Log("Congratulations, you reached the Level Objective");
                //reset birdsMatched counter
                //birdsMatched = 0;
                //go to the win scene/move to the next scene (dialouge or next level or win screen w/ score)
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

            }

            //display the amount of objective matches
            objectiveDisplay.text = obstaclesMatched + "/" + objectiveGoal + "Blue Dogs Matched";
        }


        //level five objective, count dogs matched (type = 3)
        if (boardScript.levelIndex == 5)
        {
            if (boardScript.matchType == 3)
            {
                dogsMatched += boardScript.matchAmount;
                Debug.Log(dogsMatched + "/" + objectiveGoal);

                boardScript.matchType = -1;
            }

            //check if the level objective has been reached
            if (dogsMatched >= objectiveGoal)
            {
                Debug.Log("Congratulations, you reached the Level Objective");
                //reset birdsMatched counter
                //birdsMatched = 0;
                //go to the win scene/move to the next scene (dialouge or next level or win screen w/ score)
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

            }

            //display the amount of objective matches
            objectiveDisplay.text = dogsMatched + "/" + objectiveGoal + "Blue Dogs Matched";
        }

        //test Check if the matchType int value is 0 (the bird's Type value), if so add the matched amount of bird tiles to the counter
        /*if (boardScript.matchType == 0)
        {
            birdsMatched += boardScript.matchAmount;
            Debug.Log(birdsMatched + "/" + objectiveGoal);

            //reset the matchType, otherwise the if will keep running until a different match is made
            boardScript.matchType = -1;
        }*/

        //check if the specific iconsMatched are greater than or equal to the objectiveGoal, if so player wins the level
        /*if (birdsMatched >= objectiveGoal)
        {
            Debug.Log("Congratulations, you reached the Level Objective");
            //reset birdsMatched counter
            //birdsMatched = 0;
            //go to the win scene/move to the next scene (dialouge or next level or win screen w/ score)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

        }*/

        //display the counters, HAVE TO CHANGE THE TYPE OF TILE MATCHED EVERY LEVEL (can be an if statement, if sceneIndex = 3, objCOunter = 5 and Type = bird)
        //objectiveDisplay.text = birdsMatched + "/" + objectiveGoal;
    }
}