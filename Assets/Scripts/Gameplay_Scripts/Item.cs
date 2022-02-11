
using UnityEngine;

[CreateAssetMenu(menuName = "Match-3/Item")]

public sealed class Item : ScriptableObject
{
    public int value;

    //a string for each type of icon
    public int type;

    public Sprite sprite;
        

}