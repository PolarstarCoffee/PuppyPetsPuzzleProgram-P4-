using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MoveDisplay : MonoBehaviour
{

    //public int moveCount = 0; //keeps a count of the moves made, a move is when a swap happens AND a match is made

    //public int moveLimit = 4; // test int var for ending the game when the moveLimit is reached, is checked for after every match. 

    public TextMeshProUGUI moveCounter; // var for the TMP to display moveCount and moveLimit

    //public static MoveCountScript instance { get; private set; } //instance (? look up what it does fully) so moves can be shown

    //ref Board.cs to get moveCount and moveLimit
    public GameObject boardObject;

    public Board boardScript;

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
        //getting the moveCount and moveLimit from Board.cs and putting them into the TMP moveCounter 
        moveCounter.text = boardScript.moveCount.ToString() + " / " + boardScript.moveLimit.ToString();
    }
}