using UnityEngine;
using JOR.Entities.Character;
using JOR.Entities;

namespace JOR.GameManager
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] private GameObject _interactionPrompt;

        private CharacterSystem _playerCharacter;

        public void Init(CharacterSystem playerCharacter)
        {
            playerCharacter.Interactor.OnNearVendor += ToggleInteractionPrompt;
            _playerCharacter = playerCharacter;
        }

        private void ToggleInteractionPrompt(Vendor _, bool enabled) => _interactionPrompt.SetActive(enabled);
    }
}
