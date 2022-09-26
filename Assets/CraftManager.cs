using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CraftManager : MonoBehaviour
{
    [SerializeField] CraftSelector craftSelector;

    public void OnClickCraftButton(int index)
    {
        Recipe.CATEGORY type = (Recipe.CATEGORY)index;
        craftSelector.gameObject.SetActive(true);
        craftSelector.Setup(type);
    }

}
