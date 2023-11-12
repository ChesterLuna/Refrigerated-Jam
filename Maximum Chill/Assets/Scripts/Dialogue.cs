using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue
{
    [SerializeField] string name;


    [SerializeField]
    public string[] nameDisplays;

    [TextArea(3,8)]
    public string[] sentences;

}
