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
        // key�� �ش��ϴ� �������� ã�� count��ŭ ����.

    }
    public bool IsCraft(Recipe recipe)
    {
        bool isCraft = true;

        // �� ������ ��Ằ for-each.
        foreach(Recipe.RecipeItem mat in  recipe.materials)
        {
            // �ش� ����� �������� �ʿ� ���������� ���ٸ�...
            if(CountOf(mat.itemKey) < mat.count)
            {
                isCraft = false;
                break;
            }
        }
        return isCraft;
    }
}
