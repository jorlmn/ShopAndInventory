using UnityEngine;
using System;
using JOR.Inputs;

namespace JOR.Entities.Character
{
    [Serializable]
    public class CharacterMovement : CharacterModule
    {
        [SerializeField] private Rigidbody2D _rigidBody;
        [SerializeField] private Transform _bodyPivot;

        private Vector2 _currentMovement;
        private bool _movementEnabled;

        public override void Init(CharacterSystem controller)
        {
            base.Init(controller);
            _movementEnabled = true;

            InputController.OnMove += GetInput;
        }

        public override void FixedUpdate()
        {
            if (!_movementEnabled)
                return;

            SetRigidBodyVelocity(_currentMovement);
        }

        public void ToggleMovement(bool enabled)
        {
            _movementEnabled = enabled;

            if (enabled)
                return;

            _currentMovement = Vector2Int.zero;
            SetRigidBodyVelocity(_currentMovement);
        }

        public override void Dispose()
        {
            InputController.OnMove -= GetInput;
        }

        private void GetInput(Vector2Int movementInput)
        {
            if (!_movementEnabled)
                return;

            float speed = _controller.Stats.CurrentSpeed;
            _currentMovement = Vector2.ClampMagnitude(new Vector2(movementInput.x, movementInput.y), 1f) * speed;
        }

        private void SetRigidBodyVelocity(Vector2 velocity)
        {
            _rigidBody.velocity = velocity;

            if (velocity.x == 0)
                return;

            // Character will face in the general direction of movement
            Vector3 newScale = Vector3.one;
            newScale.x = velocity.x < 0 ? -1 : 1;

            _bodyPivot.transform.localScale = newScale;
        }
    }
}
