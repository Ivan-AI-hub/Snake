namespace Scripts
{
    using UnityEngine;

    public class PlayerControl : MonoBehaviour
    {
        [SerializeField] private Tank _playerTank;
        [SerializeField] private DistributorLinks _distributorLinks;

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

        private void FixedUpdate()
        {
            if (Input.GetKey(KeyCode.Tab))
            {
                _distributorLinks.UI.SelectionInterface(true);
            }
            else
            {
                _distributorLinks.UI.SelectionInterface(false);

                _playerTank.Move();

                _playerTank.WeaponControl(numberWeapon);
            }
        }
    }
}
