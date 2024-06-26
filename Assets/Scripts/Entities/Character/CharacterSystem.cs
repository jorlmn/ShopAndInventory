using UnityEngine;
using System;
using System.Collections.Generic;

namespace JOR.Entities.Character
{
    public class CharacterSystem : MonoBehaviour
    {
        [SerializeField] private CharacterMovement _movement;
        [SerializeField] private CharacterInteractor _interactor;
        [SerializeField] private CharacterStats _stats;
        [SerializeField] private CharacterGear _gear;

        private CharacterInventory _characterInventory;

        private List<CharacterModule> _characterModules;

        public CharacterMovement Movement => _movement;
        public CharacterStats Stats => _stats;
        public CharacterInteractor Interactor => _interactor;
        public CharacterInventory Inventory => _characterInventory;

        public void Init()
        {
            _characterInventory = new CharacterInventory(null, null, new List<ItemData>());

            _characterModules = new List<CharacterModule>()
            {
                _movement,
                _interactor,
                _stats,
                _gear
            };

            _characterModules.ForEach(m => m.Init(this));
        }

        private void Update() => _characterModules.ForEach(m => m.Update());
        private void FixedUpdate() => _characterModules.ForEach(m => m.FixedUpdate());
        private void OnDestroy() => _characterModules.ForEach(m => m.Dispose());
    }

    [Serializable]
    public abstract class CharacterModule
    {
        protected CharacterSystem _controller;

        public virtual void Init(CharacterSystem controller)
        {
            _controller = controller;
        }

        public virtual void Update() { }
        public virtual void FixedUpdate() { }
        public virtual void Dispose() { }

    }
}
