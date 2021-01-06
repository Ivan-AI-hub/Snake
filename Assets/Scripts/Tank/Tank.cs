namespace Scripts
{
    using System.Collections.Generic;
    using UnityEngine;

    public class Tank : MonoBehaviour
    {
        [SerializeField] private List<Weapon> _weapons = new List<Weapon>();

        [SerializeField] private Transform _towerTransform;

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
        }

        public void WeaponControl(int index)
        {
            _weapons[index].ChekAmmo();

            _weapons[index].Controll();

            if (Input.GetAxis("Fire1") > 0)
            {
                _weapons[index].Fire();
            }
        }


    }
}
