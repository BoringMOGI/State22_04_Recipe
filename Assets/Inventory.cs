using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


public class Inventory : MonoBehaviour
{
    public static Inventory Instance { get; private set; }

    [SerializeField] List<Item> itemList;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        itemList = new List<Item>();

        itemList.Add(ItemManager.Instance.GetItem(ITEM_KEY.Stone, 4));
        itemList.Add(ItemManager.Instance.GetItem(ITEM_KEY.Dirt, 4));
        itemList.Add(ItemManager.Instance.GetItem(ITEM_KEY.Stone, 4));
        itemList.Add(ItemManager.Instance.GetItem(ITEM_KEY.Stone, 4));
    }

    public int CountOf(ITEM_KEY key)
    {
        return itemList
                .Where(item => item.data.name == key.ToString())
                .Select(item => item.count).Sum();
    }

    public void AddItem(Item item)
    {
        itemList.Add(item);
    }
    public void DropItem(ITEM_KEY key, int count)
    {
        // key에 해당하는 아이템을 찾고 count만큼 제거.

    }
    public bool IsCraft(Recipe recipe)
    {
        bool isCraft = true;

        // 각 레시피 재료별 for-each.
        foreach(Recipe.RecipeItem mat in  recipe.materials)
        {
            // 해당 재료의 소지수가 필요 소지수보다 적다면...
            if(CountOf(mat.itemKey) < mat.count)
            {
                isCraft = false;
                break;
            }
        }
        return isCraft;
    }
}
