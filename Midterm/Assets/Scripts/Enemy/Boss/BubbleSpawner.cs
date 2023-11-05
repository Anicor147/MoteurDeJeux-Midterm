using System;
using System.Collections;
using UnityEngine;

namespace Enemy.Boss
{
    public class BubbleSpawner : MonoBehaviour
    {
        [SerializeField] private BossObjectPool bossObjectPool;
        private float angle;

        private void Start()
        {
            StartCoroutine(SpawnCoroutine());
        }

        IEnumerator SpawnCoroutine()
        {
            while (true)
            {
                Quaternion spawnRotation = Quaternion.identity;
                for (int i = 0; i < 360; i++ )
                {
                    var ball = bossObjectPool.GetObject();
                    ball.transform.SetPositionAndRotation(transform.position, spawnRotation);
                    ball.gameObject.SetActive(true);
                    spawnRotation *= Quaternion.Euler(0,0,angle);
                    angle += 2;
                }

                yield return new WaitForSeconds(1f);
            }
        }
    }
}