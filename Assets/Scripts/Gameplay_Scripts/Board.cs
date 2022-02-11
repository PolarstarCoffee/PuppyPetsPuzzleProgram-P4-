using DG.Tweening;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;




public sealed class Board : MonoBehaviour
{
    public static Board Instance { get; private set; }



    public Row[] rows;

    public Tile[,] Tiles { get; private set; }

    public int Width => Tiles.GetLength(dimension:0);
    public int Height => Tiles.GetLength(dimension:1);

    private readonly List<Tile> _Selection = new();

    private const float TweenDuration = 0.25f;
    private void Awake() => Instance = this;

    public int moveCount = 0; //keeps a count of the moves made, a move is when a swap happens AND a match is made

    public int moveLimit = 4; // test int var for ending the game when the moveLimit is reached, is checked for after every match.

    //gets the Type of Item that was matched
    public int matchType;
    //getting the amount of tiles matched for the ObjectiveCounter.cs
    public int matchAmount;

    //public MoveCountScript moveDisplay; //getting the MoveCountScript 

    private void Start()
    {
        Tiles = new Tile[rows.Max(selector: row => row.tiles.Length), rows.Length];


        for (var y = 0; y < Height; y++)
        {

            for (var x = 0; x < Width; x++)
            {


                var tile = rows[y].tiles[x];
                tile.x = x;
                tile.y = y;


                Tiles[x, y] = tile;

                tile.Item = Item_Database.Items[Random.Range(0, Item_Database.Items.Length)];

                   

                

            }
        }


    }

    private void Update()
    {
        if (!Input.GetKeyDown(KeyCode.A)) return;

        foreach (var connectedTile in Tiles[0, 0].GetConnectedTiles()) connectedTile.icon.transform.DOScale(1.25f, TweenDuration).Play();
    }

    //class for selecting two tiles
    public async void Select(Tile tile)
    {
        //if( !_Selection.Contains(tile))_Selection.Add(tile);

        if( !_Selection.Contains(tile))
        {
            //only choose another tile neighboring the first chosen tile
            if (_Selection.Count > 0)
            {
                //unity does not have Array, need to use System.Array... or list.IndexOf
                //making sure the ideex of the _Selection[0] is not -1
                if (System.Array.IndexOf(_Selection[0].Neighbours, tile) != -1)
                {
                    _Selection.Add(tile);
                }
            }
            else
            {
                _Selection.Add(tile);
            }
        }

        if (_Selection.Count < 2) return;

        Debug.Log($"Selected 2 Tiles @ ({_Selection[0].x}, {_Selection[0].y}) and ({_Selection[1].x}, {_Selection[1].y}) ");

        await Swap(_Selection[0], _Selection[1]);


        if (CanPop())  //Checks to see if it can be "popped" 
        {
            Pop();

            moveCount += 1; //adds one to the moveCount var

            if (moveCount >= moveLimit) //check if player's moveCount is greater than the moveLimit, if so end the level 
            {
                Debug.Log("moveCount has reached moveLimit"); //implement a scene index, sending the player to a end/retry scene
                SceneManager.LoadScene("End Scene"); //Boots player to end scene on moveCount Limit reached 
            }
           
        }
        else
        {
            await Swap(_Selection[0], _Selection[1]); //Swaps back if no match is made 
        }

       

        _Selection.Clear();


    }



    public async Task Swap(Tile tile1, Tile tile2)
    {
        var icon1 = tile1.icon;
        var icon2 = tile2.icon;

        var icon1Transform = icon1.transform;
        var icon2Transform = icon2.transform;




        var sequence = DOTween.Sequence();


        sequence.Join(icon1Transform.DOMove(icon2Transform.position, TweenDuration))
                .Join(icon2Transform.DOMove(icon1Transform.position, TweenDuration));

        await sequence.Play().AsyncWaitForCompletion();


        icon1Transform.SetParent(tile2.transform);
        icon2Transform.SetParent(tile1.transform);

        tile1.icon = icon2;
        tile2.icon = icon1;

        var tile1Item = tile1.Item;

        tile1.Item = tile2.Item;
        tile2.Item = tile1Item;


            
    }

    private bool CanPop() //Checks to see if it's a match 
    {
        for (var y = 0; y < Height; y++)
            for (var x = 0; x < Width; x++)
                if (Tiles[x, y].GetConnectedTiles().Skip(1).Count() >= 2) //More than or equal to two equals a match: Will change later  
                    return true;
        return false;
      
    }
   private async void Pop() //Removes icons from grid when matched 
    {
       for ( var y = 0; y < Height; y++ ) 
        {
            for ( var x = 0;x < Width; x++ )
            {
                var tile = Tiles[x, y]; //Tiles variable to use in THIS method 

                var connectedTiles = tile.GetConnectedTiles(); //local variable for passing along GetConnectedTiles method 

                if (connectedTiles.Skip(1).Count() < 2) continue; //If 3 tiles aren't connected, continue 

                var deflateSequence = DOTween.Sequence(); //Intialize pop sequence 

                foreach (var connectedTile in connectedTiles) deflateSequence.Join(connectedTile.icon.transform.DOScale(Vector3.zero, TweenDuration)); //Pop sequence using DOTween

                await deflateSequence.Play().AsyncWaitForCompletion();  //Waits until it's finished playing until doing it over again. 

                Score_Script.instance.Score += tile.Item.value * connectedTiles.Count;

                //get the Item Type which the connected tiles are
                matchType = tile.Item.type;
                //Debug.Log(matchType + "is the Item matched");

                //getting the amount of tiles matched
                matchAmount = connectedTiles.Count;

                var inflateSequence = DOTween.Sequence();
                foreach (var connectedTile in connectedTiles) //for each connected tile within our Pop method 
                {
                    connectedTile.Item = Item_Database.Items[Random.Range(0, Item_Database.Items.Length)]; //repopulates the grid after a "pop"

                    inflateSequence.Join(connectedTile.icon.transform.DOScale(Vector3.one, TweenDuration)); //actual code to animate in the repopulation utlilziing DOTween 
                }

                await inflateSequence.Play().AsyncWaitForCompletion();


                x = 0;
                y = 0;  //Reset 
            }
        } 

    }

} 





      