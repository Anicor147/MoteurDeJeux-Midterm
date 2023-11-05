using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Enemy.Boss
{
    public class BossObjectPool : MonoBehaviour
    {
        private List<PoolObject> children;
        private int poolIndex;

        private void Awake()
        {
            children = GetComponentsInChildren<PoolObject>(includeInactive:true).ToList();
        }

        void Start()
        {
            Debug.Log(children.Count);
        }

        internal PoolObject GetObject()
        {
            poolIndex %= children.Count;
            var next = children[poolIndex++];
            next.Reset();
            return next;
        }
    }
}
