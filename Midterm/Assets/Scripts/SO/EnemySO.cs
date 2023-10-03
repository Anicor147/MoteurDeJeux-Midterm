using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Enemy Data", menuName = "Enemy/Enemy Data")]
public class EnemySO : ScriptableObject
{
    public float lifePoint;
    public float attackDamage;
    public float speed;
    public float range;
}
