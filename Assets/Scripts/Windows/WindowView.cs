using UnityEngine;

namespace Windows
{
    [RequireComponent(typeof(CanvasGroup))]
    internal class WindowView : MonoBehaviour
    {
        [SerializeField] private Window _window;

        private CanvasGroup _canvasGroup;

        private void Awake()
        {
            _canvasGroup = GetComponent<CanvasGroup>();
            _window.ActivityChanged += UpdateActivity;
            _window.InteractableChanged += UpdateInteractable;
        }

        private void OnDestroy()
        {
            _window.ActivityChanged -= UpdateActivity;
            _window.InteractableChanged -= UpdateInteractable;
        }

        private void UpdateActivity()
        {
            if (_window.IsActive)
            {
                transform.SetAsLastSibling();
                gameObject.SetActive(true);
            }
            else
            {
                gameObject.SetActive(false);
            }
        }

        private void UpdateInteractable() =>
            _canvasGroup.interactable = _window.IsInteractable;
    }
}