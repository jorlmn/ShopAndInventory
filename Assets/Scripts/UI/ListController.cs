using System;
using System.Collections.Generic;
using UnityEngine;
using JOR.Shared;
using System.Linq;
using UnityEngine.EventSystems;

namespace JOR.UI
{
    [Serializable]
    public class ListController<TView, TData> where TView : ItemView<TData> where TData : class
    {
        [SerializeField] private TView _itemPrefab;
        [SerializeField] private RectTransform _container;

        public List<TView> ActiveViews => _objectPool.ActiveItems;

        public Action<TData, bool> OnSubmit = delegate { };
        public Action<TView> OnAfterMake = delegate { };

        protected List<TData> _lastSource;

        private ObjectPool<TView> _objectPool;

        public void Init()
        {
            _objectPool = new MonoBehaviourObjectPool<TView>(_itemPrefab, _container);
            _lastSource = new List<TData>();
        }

        public void RefreshList(IEnumerable<TData> views)
        {
            ClearList();

            foreach (TData data in views)
            {
                SpawnView(data);
            }

            _lastSource = views.ToList();
        }

        public void ReshowList() => RefreshList(_lastSource);

        public void AddToList(TData data)
        {
            _lastSource.AddIfDoesntContains(data);
            SpawnView(data);
        }

        public void RemoveFromList(TData data)
        {
            _lastSource.RemoveIfContains(data);
            TView view = ActiveViews.FirstOrDefault(i => i.Content == data);
            _objectPool.ReturnToPool(view);
        }

        public void ClearList()
        {
            _objectPool.ReturnAllToPool();
        }

        private void SpawnView(TData data)
        {
            TView newItem = _objectPool.GetFromPool();
            newItem.OnSubmit = SubmitData;
            newItem.Populate(data);
            newItem.transform.SetAsLastSibling();
            newItem.gameObject.SetActive(true);
            OnAfterMake(newItem);
        }

        protected virtual void SubmitData(TData data, bool isLeftClick)
        {
            OnSubmit(data, isLeftClick);
        }
    }

    public abstract class ItemView<TData> : MonoBehaviour, IPointerDownHandler, IPointerUpHandler where TData : class
    {
        public TData Content;

        public Action<TData, bool> OnSubmit = delegate { };

        public virtual void Populate(TData data)
        {
            Content = data;
        }

        public void OnPointerDown(PointerEventData eventData) { }

        public void OnPointerUp(PointerEventData eventData)
        {
            if (eventData.button == PointerEventData.InputButton.Left)
            {
                OnSubmit(Content, true);
                SubmitLeftClick();
            }
            else if (eventData.button == PointerEventData.InputButton.Right)
            {
                OnSubmit(Content, false);
                SubmitRightClick();
            }
        }

        public virtual void Dispose() { }

        protected virtual void SubmitLeftClick() { }
        protected virtual void SubmitRightClick() { }
    }
}
