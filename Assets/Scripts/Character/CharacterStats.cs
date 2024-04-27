﻿using System;

namespace JOR.Character
{
    [Serializable]
    public class CharacterStats : CharacterModule
    {
        private int _wealth;
        private float _currentSpeed;

        public event Action<int> OnChangeWealth;

        public float CurrentSpeed => _currentSpeed;

        public override void Init(CharacterSystem controller)
        {
            base.Init(controller);
            _currentSpeed = 2;
        }

        public void ChangeWealth(int value)
        {
            _wealth += value;
            OnChangeWealth?.Invoke(_wealth);
        }
    }
}