using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CraftManager : MonoBehaviour
{
    [SerializeField] CraftSelector craftSelector;
    [SerializeField] GameObject craftDetail;


    private void Start()
    {
        craftSelector.gameObject.SetActive(false);
        craftDetail.gameObject.SetActive(false);
    }

    public void OnClickCraftButton(int index)
    {
        Recipe.TYPE type = (Recipe.TYPE)index;
        craftSelector.gameObject.SetActive(true);
        craftSelector.Setup(type);
    }

}
