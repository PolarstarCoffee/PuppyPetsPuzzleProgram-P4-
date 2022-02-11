using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Objective_Counter : MonoBehaviour
{
    //Variables
    //Test Objective amount
    public int objectiveGoal = 3;
    //int var for counting amount of Icons matched for each type of pet
    public int dogsMatched = 0;
    public int catsMatched = 0;
    public int birdsMatched = 0;

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
    }

    // Update is called once per frame
    void Update()
    {
        //test Check if the matchType int value is 0 (the bird's Type value), if so add the matched amount of bird tiles to the counter
        if (boardScript.matchType == 0)
        {
            birdsMatched += boardScript.matchAmount;
            Debug.Log(birdsMatched + "/" + objectiveGoal);

            //reset the matchType, otherwise the if will keep running until a different match is made
            boardScript.matchType = -1;
        }

        //check if the specific iconsMatched are greater than or equal to the objectiveGoal, if so player wins the level
        if (birdsMatched >= objectiveGoal)
        {
            Debug.Log("Congratulations, you reached the Level Objective");
            //reset birdsMatched counter
            //birdsMatched = 0;
            //go to the win scene/move to the next scene (dialouge or next level or win screen w/ score)
        }

        //display the counters, HAVE TO CHANGE THE TYPE OF TILE MATCHED EVERY LEVEL (can be an if statement, if sceneIndex = 3, objCOunter = 5 and Type = bird)
        objectiveDisplay.text = birdsMatched + "/" + objectiveGoal;
    }
}