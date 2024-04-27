using UnityEngine;
using System;

namespace JOR.InputManager
{
    public class InputManager
    {
        public event Action OnSubmit;
        public event Action<Vector2Int> OnMove;

        private const KeyCode SubmitKey = KeyCode.E;
        private const KeyCode ForwardKey = KeyCode.W;
        private const KeyCode DownKey = KeyCode.S;
        private const KeyCode RightKey = KeyCode.D;
        private const KeyCode LeftKey = KeyCode.A;

        public void Update()
        {
            CheckMovement();

            if (Input.GetKeyDown(SubmitKey))
                OnSubmit?.Invoke();
        }

        private void CheckMovement()
        {
            bool isPressingForwardKey = IsPressingKey(ForwardKey);
            bool isPressingDownKey = IsPressingKey(DownKey);

            int verticalInput = 0;
 
            if (isPressingForwardKey && !isPressingDownKey)
            {
                verticalInput = 1;
            }
            else if (isPressingDownKey && !isPressingForwardKey)
            {
                verticalInput = -1;
            }

            bool isPressingRightKey = IsPressingKey(RightKey);
            bool isPressingLeftKey = IsPressingKey(LeftKey);

            int horizontalInput = 0;
 
            if (isPressingRightKey && !isPressingLeftKey)
            {
                horizontalInput = 1;
            }
            else if (isPressingLeftKey && !isPressingRightKey)
            {
                horizontalInput = -1;
            }

            OnMove?.Invoke(new Vector2Int(horizontalInput, verticalInput));
        }

        private bool IsPressingKey(KeyCode key) => Input.GetKey(key);
    }
}

