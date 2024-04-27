using UnityEngine;
using System;
using System.Collections.Generic;

namespace JOR.Character
{
    public class CharacterSystem : MonoBehaviour
    {
        [SerializeField] private CharacterMovement _movement;
        [SerializeField] private CharacterInteractor _interactor;
        [SerializeField] private CharacterStats _stats;

        private List<CharacterModule> _characterModules;

        public CharacterStats Stats => _stats;

        private void Awake()
        {
            _characterModules = new List<CharacterModule>()
            {
                _movement,
                _interactor,
                _stats
            };

            _characterModules.ForEach(m => m.Init(this));
        }

        public void Init() { }

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
