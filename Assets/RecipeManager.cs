using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class RecipeManager : MonoBehaviour
{
    Dictionary<Recipe.CATEGORY, List<Recipe>> datas;

    public static RecipeManager Instance { get; private set; }
    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        datas = new Dictionary<Recipe.CATEGORY, List<Recipe>>();
        for(Recipe.CATEGORY type = 0; type <Recipe.CATEGORY.Count; type++)
            datas.Add(type, new List<Recipe>());

        // ������ �������� ��� �����Ǹ� ã�´�.
        // ���� Ÿ�Ժ��� �з��Ѵ�.
        Recipe[] recipes = Resources.LoadAll<Recipe>("Recipe");
        for (Recipe.CATEGORY type = 0; type < Recipe.CATEGORY.Count; type++)
            datas[type].AddRange(recipes.Where(r => r.type == type));
    }

    public Recipe[] GetRecipeFromType(Recipe.CATEGORY type)
    {
        return datas[type].ToArray();
    }

}
