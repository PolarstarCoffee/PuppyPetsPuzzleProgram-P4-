using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable] //Marked as Serializable so it can be edited 
public class Dialogue //Pass to Dialogue manager to start a new Dialouge with all the info needed. 
{

    public string name;
    [TextArea(3, 10)] //Text space 
    public string[] sentences; //Sentences to load into queue 
}
