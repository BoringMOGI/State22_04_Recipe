using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Item
{
    public ItemData data;
    public int count;

    public Item Copy()
    {
        Item item = new Item();
        item.data = data;
        item.count = count;
        return item;
    }
}
