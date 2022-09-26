using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CraftDetail : MonoBehaviour
{
    [SerializeField] Image itemImage;
    [SerializeField] Text itemText;
    [SerializeField] Text contentText;

    [Header("Slot")]
    [SerializeField] CraftDetail_Slot prefab;
    [SerializeField] Transform prefabParent;

    ItemManager itemManager;
    Inventory inventory;
    Recipe recipe;

    public void Setup(Recipe recipe)
    {
        // ĳ��.
        itemManager = ItemManager.Instance;
        inventory = Inventory.Instance;

        this.recipe = recipe;

        ItemData resultItem = ItemManager.Instance.GetItemData(recipe.resultItem);

        itemImage.sprite = resultItem.sprite;
        itemText.text = resultItem.name;
        contentText.text = resultItem.content;

        // ��� ����.
        ClearSlot();
        foreach(Recipe.RecipeItem mat in recipe.materials)
        {
            CraftDetail_Slot slot = Instantiate(prefab, prefabParent);      // ����� ����.
            ItemData matData = itemManager.GetItemData(mat.itemKey);        // ����� ������.

            // ���� ����.
            // ��� ������, ������, �ʿ��.
            slot.SetItem(matData, inventory.CountOf(mat.itemKey), mat.count);
        }
    }

    public void OnCraft()
    {
        if (!inventory.IsCraft(recipe))
            return;

        inventory.AddItem(itemManager.GetItem(recipe.resultItem));
    }

    private void ClearSlot()
    {
        foreach(Transform child in prefabParent)
            Destroy(child.gameObject);
    }
}
