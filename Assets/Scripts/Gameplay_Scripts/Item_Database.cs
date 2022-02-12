using UnityEngine;




public static class Item_Database
{
    //cannot be set outside this class w/ private
    public static Item[] Items { get; private set; }

    //goes to the Resources folder and grab all Item type assets to load them 
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]private static void Initialize() => Items = Resources.LoadAll<Item>(path:"Items/");

}