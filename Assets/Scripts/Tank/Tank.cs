namespace Scripts
{
    using System.Collections.Generic;
    using UnityEngine;

    public class Tank : MonoBehaviour
    {
        [SerializeField] private List<Weapon> _weapons = new List<Weapon>();

        [SerializeField] private Transform _towerTransform;

        private GameObject _aim;

        [SerializeField] private float _aimSpeed;
        [SerializeField] private float _rotateTowerSpeed;
        [SerializeField] private float _rotateHullSpeed;
        [SerializeField] private float _moveSpeed;

        public void Move()
        {
            float x = Input.GetAxis("Horizontal") * _moveSpeed;
            float y = Input.GetAxis("Vertical") * _moveSpeed;

            transform.Translate(0, y * Time.fixedDeltaTime, 0);

            if (y < 0)
            {
                transform.Rotate(0, 0, _rotateHullSpeed * x / 4);
            }
            else
            {
                transform.Rotate(0, 0, _rotateHullSpeed * -x / 4);
            }

            _towerTransform.rotation.Normalize();
            _aim.transform.rotation = new Quaternion(0, 0, 0, _aim.transform.rotation.w);
        }

        public void ChangeDirectionTower()
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

                _aim.transform.position = Vector3.MoveTowards(_aim.transform.position, aimTarget + Vector3.forward, _aimSpeed * Time.fixedDeltaTime);
            }
            else
            {
                _aim.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                _aim.SetActive(true);
            }
        }

        public void WeaponFire(int index)
        {
            _weapons[index].ChekAmmo();
            if (Input.GetAxis("Fire1") > 0)
            {
                _weapons[index].Fire();
            }
        }

        private void Start()
        {
            DistributorLinks _distributorLinks = FindObjectOfType<DistributorLinks>();

            _aim = _distributorLinks.Aim;

            _aim.SetActive(false);
        }
    }
}
