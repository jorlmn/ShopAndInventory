using JOR.Entities.Character;
using JOR.Entities.Consumables;
using JOR.Inputs;
using UnityEngine;

namespace JOR.GameManager
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private CharacterSystem _playerCharacter;
        [SerializeField] private ConsumablesSpawner _consumablesSpawner;

        private InputController _inpuController;

        private void Start()
        {
            _inpuController = new InputController();
            _playerCharacter.Init();
            _consumablesSpawner.Init();
        }

        private void Update()
        {
            _inpuController.Update();
        }
    }
}
