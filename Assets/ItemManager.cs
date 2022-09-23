using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ItemManager : MonoBehaviour
{
    public static ItemManager Instance { get; private set; }

    [SerializeField] TextAsset sheet;
    [SerializeField] ItemData[] items;

    private void Awake()
    {
        Instance = this;
    }


    private void Start()
    {
        List<ItemData> list = new List<ItemData>();
        string[] itemString = sheet.text.Split('\n');
        bool isHead = true;
        foreach (string line in itemString)
        {
            if(isHead || string.IsNullOrEmpty(line))
            {
                isHead = false;
                continue;
            }
                        
            string[] data = line.Split(',');

            ItemData newItem = new ItemData();
            newItem.id = int.Parse(data[0]);
            newItem.name = data[1];
            newItem.material = Resources.Load<Material>($"Texture/Materials/{data[2]}");
            newItem.sprite = Resources.Load<Sprite>($"Sprite/{data[2]}");
            newItem.content = data[3];
            newItem.type = data[4];

            list.Add(newItem);
        }

        items = list.ToArray();
    }

    public ItemData GetItemData(string name)
    {
        ItemData search = items.Where(item => item.name.Equals(name)).First();
        return search;
    }
    public Item GetItem(string name)
    {
        Item newItem = new Item();
        newItem.data = GetItemData(name);
        newItem.count = 1;
        return newItem;
    }
}
