using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System.Linq;
using UnityEngine;

public class LootGenerator : MonoBehaviour
{
    [SerializeField] private Text itemNameText;
    [SerializeField] private LootTable lootTable;

    public void OnLootButton()
    {
        itemNameText.text = lootTable.GetRandomItem().itemName;
    }
}


