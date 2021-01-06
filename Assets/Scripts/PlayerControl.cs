namespace Scripts
{
    using UnityEngine;

    public class PlayerControl : MonoBehaviour
    {
        [SerializeField] private Tank _playerTank;
        [SerializeField] private DistributorLinks _distributorLinks;

        private int numberWeapon = 0;

        private bool towerRotate = true;

        #region Select
        public void CannonSelect()
        {
            numberWeapon = 0;
            towerRotate = true;
        }

        public void MortalSelect()
        {
            numberWeapon = 1;
            towerRotate = false;
        }

        public void FlameSelect()
        {
            numberWeapon = 2;
            towerRotate = true;
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

                _playerTank.WeaponFire(numberWeapon);

                if (towerRotate)
                {
                    _playerTank.ChangeDirectionTower();
                }
                else
                {
                    _playerTank.AimControl();
                }
            }
        } 
    }
}
