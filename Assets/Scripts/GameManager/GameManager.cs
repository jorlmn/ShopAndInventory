using JOR.Character;
using JOR.Inputs;
using UnityEngine;

namespace JOR.GameManager
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private CharacterSystem _playerCharacter;

        private InputController _inpuController;

        private void Start()
        {
            _inpuController = new InputController();
            _playerCharacter.Init();
        }

        private void Update()
        {
            _inpuController.Update();
        }
    }
}
