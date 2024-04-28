using UnityEngine;
using System;

namespace JOR.Inputs
{
    public class InputController
    {
        public static event Action OnSubmit;
        public static event Action OnToggleInventory;
        public static event Action OnCancel;
        public static event Action<Vector2Int> OnMove;

        private const KeyCode SubmitKey = KeyCode.E;
        private const KeyCode InventoryKey = KeyCode.I;
        private const KeyCode CancelKey = KeyCode.Escape;

        public void Update()
        {
            int horizontalInput = Mathf.RoundToInt(Input.GetAxisRaw("Horizontal"));
            int verticalInput = Mathf.RoundToInt(Input.GetAxisRaw("Vertical"));

            OnMove?.Invoke(new Vector2Int(horizontalInput, verticalInput));

            if (Input.GetKeyDown(SubmitKey))
                OnSubmit?.Invoke();

            if (Input.GetKeyDown(CancelKey))
                OnCancel?.Invoke();

            if (Input.GetKeyDown(InventoryKey))
                OnToggleInventory?.Invoke();
        }
    }
}

