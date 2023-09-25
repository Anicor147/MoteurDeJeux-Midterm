using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "CharacterData", menuName = "Character/Character Data")]
public class CharacterSOScript : ScriptableObject
{
    public float lifePoint;
    public float attackDamage;
    public float manaPoint;
    public float speed;
}
