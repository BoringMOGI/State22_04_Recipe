using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CraftDetail_Slot : MonoBehaviour
{
    [SerializeField] Image itemImage;
    [SerializeField] Text nameText;
    [SerializeField] Text countText;

    public void SetItem(ItemData itemData, int hasCount, int needCount)
    {
        itemImage.sprite = itemData.sprite;
        nameText.text = itemData.name;
        countText.text = $"{hasCount}/{needCount}";
    }

}
