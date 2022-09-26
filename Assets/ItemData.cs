using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public partial class ItemData
{
    public int id;
    public string name;
    public Material material;
    public Sprite sprite;
    public string content;
    public string type;
}

public enum ITEM_KEY
{
    Stone,
    Grass,
    Dirt,
    Planks,
    Log,
}


