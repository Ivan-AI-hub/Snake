using UnityEngine;

namespace Scripts
{
    public class TankControl : MonoBehaviour
    {

        [SerializeField] private CannonShot _cannon;
        [SerializeField] private FlamethrowerShot _flamethrower;
        [SerializeField] private MortalShot _mortal;

        [SerializeField] private Transform _towerTransform;

        [SerializeField] private GameObject _aim;

        [SerializeField] private float _rotateTowerSpeed;
        [SerializeField] private float _rotateHullSpeed;
        [SerializeField] private float _moveSpeed;

        private void Awake()
        {
            _aim.SetActive(false);
        }

        public void TankMove()
        {

            float x = Input.GetAxis("Horizontal") * _moveSpeed;
            float y = Input.GetAxis("Vertical") * _moveSpeed;

            transform.Translate(0, y * Time.fixedDeltaTime, 0);

            if (y < 0)
                transform.Rotate(0, 0, _rotateHullSpeed * x / 4);
            else
                transform.Rotate(0, 0, _rotateHullSpeed * -x / 4);

            _towerTransform.rotation.Normalize();
            _aim.transform.rotation.Normalize();

        }

        public void ChangeDirection()
        {
            _aim.SetActive(false);

            Vector3 aimTarget = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3 aimDir = aimTarget - _towerTransform.position;

            aimDir.z = _towerTransform.up.z;
            aimDir = aimDir.normalized;

            _towerTransform.up = Vector3.MoveTowards(_towerTransform.up, aimDir, _rotateTowerSpeed * Time.fixedDeltaTime);
        }

        public void AimControl()
        {

            if (_aim.activeSelf)
            {
                Vector3 aimTarget = Camera.main.ScreenToWorldPoint(Input.mousePosition);

                _aim.transform.position = Vector3.MoveTowards(_aim.transform.position, aimTarget + Vector3.forward, _rotateTowerSpeed * Time.fixedDeltaTime);
            }
            else
            {
                _aim.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition); 
                _aim.SetActive(true);
            }
        }

        #region Getters
        public CannonShot GetCannon()
        {
            return _cannon;
        }

        public MortalShot GetMortal()
        {
            return _mortal;
        }

        public FlamethrowerShot GetFlamethrower()
        {
            return _flamethrower;
        }
        #endregion
    }
}
