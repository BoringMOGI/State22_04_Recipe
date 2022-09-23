using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftSelector : MonoBehaviour
{
    [SerializeField] CraftRecipeButton prefab;
    [SerializeField] Transform buttonParent;

    public void Setup(Recipe.TYPE type)
    {
        Recipe[] recipes = RecipeManager.Instance.GetRecipeFromType(type);

        foreach(Transform child in buttonParent)
            Destroy(child.gameObject);

        foreach(Recipe recipe in recipes)
        {
            CraftRecipeButton button = Instantiate(prefab, buttonParent);
            button.Setup(recipe, OnClickRecipeButton);
        }
    }
    public void OnClickRecipeButton(Recipe recipe)
    {

    }
}
