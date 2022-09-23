using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class RecipeManager : MonoBehaviour
{
    Dictionary<Recipe.TYPE, List<Recipe>> datas;

    public static RecipeManager Instance { get; private set; }
    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        datas = new Dictionary<Recipe.TYPE, List<Recipe>>();
        for(Recipe.TYPE type = 0; type <Recipe.TYPE.Count; type++)
            datas.Add(type, new List<Recipe>());

        // ������ �������� ��� �����Ǹ� ã�´�.
        // ���� Ÿ�Ժ��� �з��Ѵ�.
        Recipe[] recipes = Resources.LoadAll<Recipe>("Recipe");
        for (Recipe.TYPE type = 0; type < Recipe.TYPE.Count; type++)
            datas[type].AddRange(recipes.Where(r => r.type == type));
    }

    public Recipe[] GetRecipeFromType(Recipe.TYPE type)
    {
        return datas[type].ToArray();
    }

}
