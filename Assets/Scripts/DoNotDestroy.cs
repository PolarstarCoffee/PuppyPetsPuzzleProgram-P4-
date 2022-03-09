using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoNotDestroy : MonoBehaviour
{
    private void Awake()
    {
        //finding the Game Music (audiosource) tagged GameMusic
        GameObject[] musicObj = GameObject.FindGameObjectsWithTag("GameMusic");
        //only have one musicObj
        if (musicObj.Length > 1)
        {
            Destroy(this.gameObject);
        }

        //will not destroy the audiosource when loaded into a new scene
        DontDestroyOnLoad(this.gameObject);
    }
}
