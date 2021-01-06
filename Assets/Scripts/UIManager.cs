namespace Scripts
{
    using UnityEngine;
    using UnityEngine.UI;

    public class UIManager : MonoBehaviour
    {
        [SerializeField] private GameObject _selectionInterface;
        [SerializeField] private Text _infoAmmo;

        public void SetTextAmmo(string infoAmmo)
        {
            _infoAmmo.text = "Ammo:" + infoAmmo;
        }

        public void SelectionInterface(bool value)
        {
            _selectionInterface.SetActive(value);
        }
    }
}