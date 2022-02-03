using UnityEngine;




public static class Item_Database
{
    public static Item[] Items { get; private set; }

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]private static void Initialize() => Items = Resources.LoadAll<Item>(path:"Items/");

}