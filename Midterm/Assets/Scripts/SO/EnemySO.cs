using UnityEngine;

namespace SO
{
    [CreateAssetMenu(fileName = "Enemy Data", menuName = "Enemy/Enemy Data")]
    public class EnemySO : ScriptableObject
    {
        public float lifePoint;
        public float attackDamage;
        public float speed;
        public float range;
    }
}
