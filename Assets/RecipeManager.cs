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

        // 리스스 폴더에서 모든 레시피를 찾는다.
        // 이후 타입별로 분류한다.
        Recipe[] recipes = Resources.LoadAll<Recipe>("Recipe");
        for (Recipe.TYPE type = 0; type < Recipe.TYPE.Count; type++)
            datas[type].AddRange(recipes.Where(r => r.type == type));
    }

    public Recipe[] GetRecipeFromType(Recipe.TYPE type)
    {
        return datas[type].ToArray();
    }

}
