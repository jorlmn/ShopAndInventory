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
        [SerializeField] private DataModelCollection _dataModelCollection;
        [SerializeField] private Vendor _vendor;

        private InputController _inpuController;

        private void Start()
        {
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
    }
}
