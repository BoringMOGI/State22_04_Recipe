using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New recipe", menuName = "Item/New recipe")]
public class Recipe : ScriptableObject
{
    public enum TYPE
    {
        Weapon,
        Tool,
        Food,

        Count,
    }

    [System.Serializable]
    public struct RecipeItem
    {
        public string item;
        public int count;                
    }

    public TYPE type;
    public string resultItem;
    public RecipeItem[] materials;
}
