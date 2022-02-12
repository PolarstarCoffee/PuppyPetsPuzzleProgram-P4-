using UnityEngine;



public sealed class Row : MonoBehaviour
{
    //script for each Row of tiles in the scene
    //The Row script can hold X amount of tiles, held within the Tiles type array
    //the Board script creates an array of Row types, one row for each row on the board
    
    public Tile[] tiles;
}