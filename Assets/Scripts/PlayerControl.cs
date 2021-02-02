namespace Scripts
{
    using UnityEngine;

    public class PlayerControl : MonoBehaviour
    {
        private Tank _playerTank;
        private UIManager _uI;

        private int numberWeapon = 0;

        #region Select
        public void CannonSelect()
        {
            numberWeapon = 0;
        }

        public void MortalSelect()
        {
            numberWeapon = 1;
        }

        public void FlameSelect()
        {
            numberWeapon = 2;
        }
        #endregion

        private void Awake()
        {
            DistributorLinks _distributorLinks = FindObjectOfType<DistributorLinks>();
            _uI = _distributorLinks.UI;
            _playerTank = _distributorLinks.PlayerTank;
        }

        private void FixedUpdate()
        {
            if (Input.GetKey(KeyCode.Tab))
            {
                _uI.SelectionInterface(true);
            }
            else
            {
                _uI.SelectionInterface(false);

                float x = Input.GetAxis("Horizontal") ;
                float y = Input.GetAxis("Vertical") ;
                _playerTank.Move(x,y);

                _playerTank.WeaponControl(numberWeapon);
            }
        }
    }
}
