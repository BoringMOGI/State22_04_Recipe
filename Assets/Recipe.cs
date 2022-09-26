using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New recipe", menuName = "Item/New recipe")]
public class Recipe : ScriptableObject
{
    public enum CATEGORY
    {
        Weapon,
        Tool,
        Food,

        Count,
    }

    [System.Serializable]
    public struct RecipeItem
    {
        public ITEM_KEY itemKey;
        public int count;                
    }

    public CATEGORY type;
    public ITEM_KEY resultItem;
    public RecipeItem[] materials;
}
