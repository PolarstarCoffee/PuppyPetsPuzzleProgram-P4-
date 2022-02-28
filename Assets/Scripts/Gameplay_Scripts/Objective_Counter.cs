using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Objective_Counter : MonoBehaviour
{
    //Variables
    //Test Objective amount
    public int objectiveGoalOne;
    public int objectiveGoalTwo;
    public int objectiveGoalThree;
    public int objectiveGoalFour;
    //int var for counting amount of Icons matched for each type of pet
    public int shabMatched = 0;
    public int puraMatched = 0;
    public int baudMatched = 0;
    public int bnanMatched = 0;

    public int baudTotal = 0;
    public int puraTotal = 0;
    public int bnanTotal = 0;
    public int shabTotal = 0;


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
            //changed the if for matchType to not -1 so the counter puraMatched takes in all matched tiles, just counts all matches until objective
                //change later if we NEED to count each type of pet individually
            if (boardScript.matchType != -1)
            {
                puraMatched += boardScript.matchAmount;
                Debug.Log(puraMatched + "/" + objectiveGoalOne + " Pets Matched");

                //reset the matchType, otherwise will infinite add
                boardScript.matchType = -1;
            }

            //check if the level objective has been reached
            if (puraMatched >= objectiveGoalOne)
            {
                Debug.Log("Congratulations, you reached the Level Objective");
                //reset birdsMatched counter
                //birdsMatched = 0;
                //go to the win scene/move to the next scene (dialouge or next level or win screen w/ score)
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

            }

            //display the amount of objective matches
            objectiveDisplay.text = puraMatched + "/" + objectiveGoalOne + " Pets Matched";
        }



        //level two objective, count obstacles 'cleared'
        if (boardScript.levelIndex == 2)
        {
            if (boardScript.matchType == 2)
            {
                puraMatched += boardScript.matchAmount;
                Debug.Log(puraMatched + "/" + objectiveGoalOne);

                boardScript.matchType = -1;
            }

            //check if the level objective has been reached
            if (puraMatched >= objectiveGoalOne)
            {
                Debug.Log("Congratulations, you reached the Level Objective");
                //reset birdsMatched counter
                //birdsMatched = 0;
                //go to the win scene/move to the next scene (dialouge or next level or win screen w/ score)
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

            }

            //display the amount of objective matches
            objectiveDisplay.text = puraMatched + "/" + objectiveGoalOne + " Bnan Matched";
        }



        //level three objective, count cats matched (type = 1)
        if (boardScript.levelIndex == 3)
        {
            if (boardScript.matchType == 1)
            {
                puraMatched += boardScript.matchAmount;
                Debug.Log(puraMatched + "/" + objectiveGoalOne);

                boardScript.matchType = -1;
            }

            //check if the level objective has been reached
            if (puraMatched >= objectiveGoalOne)
            {
                Debug.Log("Congratulations, you reached the Level Objective");
                //reset birdsMatched counter
                //birdsMatched = 0;
                //go to the win scene/move to the next scene (dialouge or next level or win screen w/ score)
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

            }

            //display the amount of objective matches
            objectiveDisplay.text = puraMatched + "/" + objectiveGoalOne + " Pura Matched";
        }



        //level four objective, count obstacles 'cleared' (type = 4)
        if (boardScript.levelIndex == 4)
        {
            if (boardScript.matchType == 0)
            {
                puraMatched += boardScript.matchAmount;
                Debug.Log(puraMatched + "/" + objectiveGoalOne);

                boardScript.matchType = -1;
            }

            //check if the level objective has been reached
            if (puraMatched >= objectiveGoalOne)
            {
                Debug.Log("Congratulations, you reached the Level Objective");
                //reset birdsMatched counter
                //birdsMatched = 0;
                //go to the win scene/move to the next scene (dialouge or next level or win screen w/ score)
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

            }

            //display the amount of objective matches
            objectiveDisplay.text = puraMatched + "/" + objectiveGoalOne + " Baud Matched";
        }


        //level five objective, count dogs matched (type = 3)
        if (boardScript.levelIndex == 5)
        {
            if (boardScript.matchType == 3)
            {
                puraMatched += boardScript.matchAmount;
                Debug.Log(puraMatched + "/" + objectiveGoalOne);

                boardScript.matchType = -1;
            }

            //check if the level objective has been reached
            if (puraMatched >= objectiveGoalOne)
            {
                Debug.Log("Congratulations, you reached the Level Objective");
                //reset birdsMatched counter
                //birdsMatched = 0;
                //go to the win scene/move to the next scene (dialouge or next level or win screen w/ score)
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

            }

            //display the amount of objective matches
            objectiveDisplay.text = puraMatched + "/" + objectiveGoalOne + " Shab Matched";
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


        //checking if there are LESS THAN 2 OF ANY pet icons, since it results in a soft lock, if true, send to retry scene

        for (var y = 0; y < boardScript.Height; y++)
        {

            for (var x = 0; x < boardScript.Width; x++)
            {
                //adding one to the baudTotal counter if the Item is Baud
                if (boardScript.Tiles[x, y].Item == Item_Database.Items[0])
                {
                    baudTotal += 1;
                }
                else if (boardScript.Tiles[x, y].Item == Item_Database.Items[1])
                {
                    puraTotal += 1;
                }
                else if (boardScript.Tiles[x, y].Item == Item_Database.Items[2])
                {
                    bnanTotal += 1;
                }
                else if (boardScript.Tiles[x, y].Item == Item_Database.Items[3])
                {
                    shabTotal += 1;
                }
            }
        }

        //If ANY of the totals are less than 2, send to retry scene
        //if (baudTotal <= 2 || puraTotal <= 2 || bnanTotal <= 2 || shabTotal <= 2)
        {
            //Debug.Log("Softlock Reset");
                    }

        

    }
}