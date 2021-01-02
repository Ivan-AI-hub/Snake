using UnityEngine;

namespace Scripts
{
    public class PlayerControl : MonoBehaviour
    {
        [SerializeField] private TankControl _playerTank;
        [SerializeField] private GameObject _canvas;

        private CannonShot _cannon;
        private MortalShot _mortal;
        private FlamethrowerShot _flamethrower;

        private int NumberWeapon = 1;
        private void Awake()
        {
            _cannon = _playerTank.GetCannon();
            _mortal = _playerTank.GetMortal();
            _flamethrower = _playerTank.GetFlamethrower();
        }

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

                if (NumberWeapon == 1)
                {
                    CannonControl();
                }
                else if (NumberWeapon == 2)
                {
                    MortalControl();
                }
                else if (NumberWeapon == 3)
                {
                    FlameControl();
                }
            }
        }

        private void CannonControl()
        {
            _playerTank.ChangeDirection();
            if (Input.GetKey(KeyCode.Mouse0))
                _cannon.Fire();
        }

        private void MortalControl()
        {
            _playerTank.AimControl();
            if (Input.GetKey(KeyCode.Mouse0))
                _mortal.Fire();
        }

        private void FlameControl()
        {
            _playerTank.ChangeDirection();
            if (Input.GetKey(KeyCode.Mouse0))
                _flamethrower.Fire();
        }

        #region Select
        public void CannonSelect()
        {
            NumberWeapon = 1;
        }

        public void MortalSelect()
        {
            NumberWeapon = 2;
        }

        public void FlameSelect()
        {
            NumberWeapon = 3;
        }
        #endregion
    }
}
