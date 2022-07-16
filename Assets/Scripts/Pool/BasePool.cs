using UnityEngine;
using UnityEngine.Pool;

namespace Pool
{
    public abstract class BasePool<T> : ScriptableObject where T: MonoBehaviour
    {
        public T PooledTextMeshPro;
        
        enum PoolType
        {
            Stack,
            LinkedList
        }

        [SerializeField] PoolType poolType;

        // Collection checks will throw errors if we try to release an item that is already in the pool.
        public bool collectionChecks = true;
        public int maxPoolSize = 10;

        IObjectPool<T> _pool;

        public IObjectPool<T> Pool
        {
            get
            {
                if (_pool == null)
                {
                    if (poolType == PoolType.Stack)
                        _pool = new ObjectPool<T>(CreatePooledItem, OnTakeFromPool, OnReturnedToPool,
                            OnDestroyPoolObject, collectionChecks, 10, maxPoolSize);
                    else
                        _pool = new LinkedPool<T>(CreatePooledItem, OnTakeFromPool, OnReturnedToPool,
                            OnDestroyPoolObject, collectionChecks, maxPoolSize);
                }

                return _pool;
            }
        }

        T CreatePooledItem()
        {
            var obj = Instantiate(PooledTextMeshPro);
            return obj;
        }

        // Called when an item is returned to the pool using Release
        void OnReturnedToPool(T system)
        {
            system.gameObject.SetActive(false);
        }

        // Called when an item is taken from the pool using Get
        void OnTakeFromPool(T system)
        {
            system.gameObject.SetActive(true);
        }

        // If the pool capacity is reached then any items returned will be destroyed.
        // We can control what the destroy behavior does, here we destroy the GameObject.
        void OnDestroyPoolObject(T system)
        {
            Destroy(system.gameObject);
        }
    }
}