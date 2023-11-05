using System;
using UnityEngine;

namespace Enemy.Boss
{
    public class BossBubbles : PoolObject

    {
        private float lifetime = 3f;
        private void Update()
        {
            lifetime -= Time.deltaTime;
            if (lifetime <= 0)
            {
                gameObject.SetActive(false);
                return;
            }
            transform.position += 5f * Time.deltaTime * transform.up;
        }
        public override void Reset()
        {
            lifetime = 2f;
        }
    }
}