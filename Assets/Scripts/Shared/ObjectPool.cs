using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace JOR.Shared
{
    public abstract class ObjectPool<T>
    {
        protected List<T> _activeItems = new();
        protected Queue<T> _disabledItems = new();

        public abstract T GetFromPool();
        public abstract void ReturnToPool(T item);

        public void ReturnListToPool(List<T> items)
        {
            items.ForEach(i => ReturnToPool(i));
        }

        public void ReturnAllToPool()
        {
            _activeItems.ToList().ForEach(i => ReturnToPool(i));
        }
        public virtual void DisposePool()
        {
            _activeItems.Clear();
            _disabledItems.Clear();
        }
    }

    public class MonoBehaviourObjectPool<T> : ObjectPool<T> where T : MonoBehaviour
    {
        private readonly T _prefab;
        private readonly Transform _parent;

        public MonoBehaviourObjectPool(T prefab, Transform parent = null)
        {
            _prefab = prefab;
            _parent = parent;
        }

        public override T GetFromPool()
        {
            T item;
            if (_disabledItems.Count > 0)
            {
                item = _disabledItems.Dequeue();
            }
            else
            {
                item = Object.Instantiate(_prefab, _parent);
            }

            _activeItems.Add(item);
            return item;
        }

        public override void ReturnToPool(T item)
        {
            item.transform.SetParent(_parent);
            item.gameObject.SetActive(false);
            _activeItems.Remove(item);
            _disabledItems.Enqueue(item);
        }

        public override void DisposePool()
        {
            _activeItems.ForEach(i => Object.Destroy(i));
            base.DisposePool();
        }
    }
}
