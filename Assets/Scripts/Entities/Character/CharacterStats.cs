using System;

namespace JOR.Entities.Character
{
    [Serializable]
    public class CharacterStats : CharacterModule
    {
        private int _wealth;
        private float _currentSpeed;

        public event Action<int> OnChangeWealth;

        public int CurrentWealth => _wealth;
        public float CurrentSpeed => _currentSpeed;

        public override void Init(CharacterSystem controller)
        {
            base.Init(controller);
            _currentSpeed = 8;
        }

        public void ChangeWealth(int value)
        {
            _wealth += value;
            OnChangeWealth?.Invoke(_wealth);
        }
    }
}
