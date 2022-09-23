using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CraftRecipeButton : MonoBehaviour
{
    [SerializeField] Image itemIcon;

    Recipe recipe;
    System.Action<Recipe> onClick;

    public void Setup(Recipe recipe, System.Action<Recipe> onClick)
    {
        this.recipe = recipe;
        this.onClick = onClick;

        ItemData data = ItemManager.Instance.GetItemData(recipe.resultItem);
        itemIcon.sprite = data.sprite;
    }

    public void OnClick()
    {
        onClick?.Invoke(recipe);
    }
}
