using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Loot Data", menuName = "Loots/Loot Data")]
public class LootSO : ScriptableObject
{
    public Sprite lootSprite;
    public string lootName;
    public int dropRate;

    public LootSO(string lootName, int dropRate)
    {
        this.lootName = lootName;
        this.dropRate = dropRate;
    }
}
