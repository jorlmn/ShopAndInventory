using JOR.Entities.Character;
using JOR.Entities;
using JOR.Inputs;
using UnityEngine;

namespace JOR.GameManager
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private CharacterSystem _playerCharacter;
        [SerializeField] private ConsumablesSpawner _consumablesSpawner;
        [SerializeField] private ShopManager _shopManager;

        private InputController _inpuController;

        private void Start()
        {
            _inpuController = new InputController();
            _playerCharacter.Init();
            _consumablesSpawner.Init();
            _shopManager.Init(_playerCharacter);
        }

        private void Update()
        {
            _inpuController.Update();
        }
    }
}
