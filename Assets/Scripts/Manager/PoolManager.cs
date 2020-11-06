using System.Collections.Generic;
using Hybrid.Base;
using Other;
using RFramework.Common.Singleton;
using UnityEngine;

namespace Manager
{
    public class PoolManager : MonoSingleton<PoolManager>
    {
        private const string PATH_PREFIX = "Actors";

        [SerializeField] private ActorTagPathDic ActorTagPathDic;

        private Dictionary<ActorTag, ViewPrefabPool> _viewPrefabPools
            = new Dictionary<ActorTag, ViewPrefabPool>();

        public View Spawn(ActorTag actorTag)
        {
            if (!_viewPrefabPools.TryGetValue(actorTag, out var pool))
            {
                pool = new ViewPrefabPool();
                pool.Prefab = Resources.Load<GameObject>($"{PATH_PREFIX}/{ActorTagPathDic[actorTag]}");
                pool.SpawnRoot = new GameObject($"__SpawnRoot_{actorTag.ToString()}")
                    .transform;
                pool.PoolRoot = new GameObject($"__PoolRoot_{actorTag.ToString()}")
                    .transform;

                pool.SpawnRoot.SetParent(transform);
                pool.SpawnRoot.localPosition = Vector3.zero;
                pool.SpawnRoot.localRotation = Quaternion.identity;
                pool.SpawnRoot.localScale = Vector3.one;

                pool.PoolRoot.SetParent(transform);
                pool.PoolRoot.localPosition = Vector3.zero;
                pool.PoolRoot.localRotation = Quaternion.identity;
                pool.PoolRoot.localScale = Vector3.one;

                _viewPrefabPools.Add(actorTag, pool);
            }

            return pool.Spawn();
        }


        public T Spawn<T>(ActorTag actorTag) where T : class, IView
        {
            return Spawn(actorTag) as T;
        }

        public bool Recycle(View view, ActorTag tag)
        {
            if (!_viewPrefabPools.TryGetValue(tag, out var pool))
            {
                Destroy(view.gameObject);
                return false;
            }

            pool.Recycle(view);
            return true;
        }
    }
}