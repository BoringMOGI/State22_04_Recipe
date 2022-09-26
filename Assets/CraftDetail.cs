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
        // 캐싱.
        itemManager = ItemManager.Instance;
        inventory = Inventory.Instance;

        this.recipe = recipe;

        ItemData resultItem = ItemManager.Instance.GetItemData(recipe.resultItem);

        itemImage.sprite = resultItem.sprite;
        itemText.text = resultItem.name;
        contentText.text = resultItem.content;

        // 재료 슬롯.
        ClearSlot();
        foreach(Recipe.RecipeItem mat in recipe.materials)
        {
            CraftDetail_Slot slot = Instantiate(prefab, prefabParent);      // 재료의 슬롯.
            ItemData matData = itemManager.GetItemData(mat.itemKey);        // 재료의 데이터.

            // 슬롯 세팅.
            // 재료 데이터, 소지수, 필요수.
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
