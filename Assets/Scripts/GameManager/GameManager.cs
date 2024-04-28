using JOR.Entities.Character;
using JOR.Entities;
using JOR.Inputs;
using UnityEngine;
using JOR.Settings;

namespace JOR.GameManager
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private CharacterSystem _playerCharacter;
        [SerializeField] private ConsumablesSpawner _consumablesSpawner;
        [SerializeField] private ShopManager _shopManager;
        [SerializeField] private DataModelCollection _dataModelCollection;
        [SerializeField] private Vendor _vendor;
        [SerializeField] private GameConfig _gameConfig;

        private InputController _inpuController;

        private void Awake()
        {
            _gameConfig.Init();
            _inpuController = new InputController();
            _dataModelCollection.Init();
            _playerCharacter.Init();
            _consumablesSpawner.Init();
            _shopManager.Init(_playerCharacter);
            _vendor.Init(_dataModelCollection.ItemSOs);
        }

        private void Update()
        {
            _inpuController.Update();
        }

        public void OnSubmitQuit() => Application.Quit();
    }
}
