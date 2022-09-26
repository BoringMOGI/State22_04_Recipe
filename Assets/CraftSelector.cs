using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftSelector : MonoBehaviour
{
    [SerializeField] CraftDetail detail;
    [SerializeField] CraftRecipeButton prefab;
    [SerializeField] Transform buttonParent;

    private void Start()
    {
        gameObject.SetActive(false);
        detail.gameObject.SetActive(false);
    }

    public void Setup(Recipe.CATEGORY type)
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
        detail.gameObject.SetActive(true);
        detail.Setup(recipe);
    }
}
