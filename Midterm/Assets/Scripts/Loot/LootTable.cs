using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class LootTable : MonoBehaviour
{
    public GameObject ItemPrefab;
    public List<LootSO> lootList = new List<LootSO>();


    LootSO GetDroppedItem()
    {
        int randomNumber = Random.Range(1, 101);
        List<LootSO> possibleItems = new List<LootSO>();
        
        foreach (LootSO item in lootList)
        {
            if (randomNumber <= item.dropRate)
            {
                possibleItems.Add(item);
            }
        }
        if (possibleItems.Count > 0)
        {
            LootSO droppedItem = possibleItems[Random.Range(0, possibleItems.Count)];
            return droppedItem;
        }
        return null;
    }


    public void InstantiateLoot(Vector3 spawnPosition)
    {
        LootSO droppedItem = GetDroppedItem();
        if (droppedItem != null)
        {
            GameObject lootGameObject = Instantiate(ItemPrefab, spawnPosition, Quaternion.identity);
            lootGameObject.GetComponent<SpriteRenderer>().sprite = droppedItem.lootSprite;
            lootGameObject.name = droppedItem.lootName;
        }

    }
}
