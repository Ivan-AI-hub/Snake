namespace Scripts
{
    using UnityEngine;

    public class PlayerControl : MonoBehaviour
    {
        [SerializeField] private TankControl _playerTank;
        [SerializeField] private GameObject _canvas;

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
                _canvas.SetActive(true);
            }
            else
            {
                _canvas.SetActive(false);

                _playerTank.TankMove();

                _playerTank.WeaponFire(numberWeapon);

                if (towerRotate)
                {
                    _playerTank.ChangeDirection();
                }
                else
                {
                    _playerTank.AimControl();
                }
            }
        }
    }
}
