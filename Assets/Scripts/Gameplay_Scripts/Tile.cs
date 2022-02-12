
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;



public sealed class Tile : MonoBehaviour
{
    public int x;
    public int y;

    private Item _item;

    
    public Item Item
    {
        get => _item;


        
        set
        {
            //if there is already a item assigned to this tile, do not do anything
            if (_item == value) return;

            //else, change the item to the value
            _item = value;

            icon.sprite = _item.sprite;


        }

    }


    public Image icon;

    public Button button;

    public Tile Left => x > 0 ? Board.Instance.Tiles[x - 1, y] : null;
    public Tile Top => y > 0 ? Board.Instance.Tiles[x, y - 1] : null;
    public Tile Right => x < Board.Instance.Width - 1 ? Board.Instance.Tiles[x + 1, y] : null;
    public Tile Bottom => y < Board.Instance.Height - 1 ? Board.Instance.Tiles[x, y + 1] : null;

    public Tile[] Neighbours => new []
    {
        Left,
        Top,
        Right,
        Bottom,
    }; 
    private void Start() => button.onClick.AddListener(call:() => Board.Instance.Select(this));

    //IF obstacle is adjacenet to a match, remove it and add to the obstacle objective counter
    //List getting tiles, just like Neighbors list, except just getting item.type = 4 obstacles
        //CURRENTLY will get the obstacle tiles, BUT will group them together so all connected obstacle tiles are matched, not just the one adjacent
        //ALSO will ONLY match the obstacle tiles adjacent to the location of the first swapped tile
    public List<Tile> GetObstacleTiles(List<Tile> excludeOne = null)
    {
        var obstacleList = new List<Tile> { this, };

        if (excludeOne == null)
        {
            excludeOne = new List<Tile> { this, };
        }
        else
        {
            excludeOne.Add(this);
        }

        //check for tile.item.type = 4
        foreach (var obstacle in Neighbours)
        {
            if (obstacle == null || excludeOne.Contains(obstacle)) continue;
            
            if (obstacle.Item.type == 4)
            {
                obstacleList.AddRange(obstacle.GetObstacleTiles(excludeOne));
            }
            
        }
        return obstacleList;

    }



    public List<Tile> GetConnectedTiles(List<Tile> exclude = null) //returns adjacent tiles 
    {
        var result = new List<Tile> { this, };

        if (exclude == null)
        {
            exclude = new List<Tile> { this, };
        }
        else
        {
            exclude.Add(this);
        }

        //added to last OR ||, only add to exclude if the neighbor.item.type does not equal the obstacle type // && neighbour.Item.type != 4)
        //  Currently will make the triangle obstacle act as a 'wild tile' after canpop is true in board
        foreach (var neighbour in Neighbours) {
            if (neighbour == null || exclude.Contains(neighbour) || neighbour.Item != Item) continue;

            result.AddRange(neighbour.GetConnectedTiles(exclude));
        }

        return result;

        }
    }














 