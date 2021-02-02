namespace Scripts
{
    using System.Collections.Generic;
    using UnityEngine;

    public class Tank : MonoBehaviour
    {
        [SerializeField] private GameObject _tower;
        [SerializeField] private Aim _aim;
        [SerializeField] private Transform _healthBar;

        [SerializeField] private List<Weapon> _weapons = new List<Weapon>();

        [SerializeField] private Transform _towerTransform;
        [SerializeField] private Rigidbody2D _rb;

        [SerializeField] private float _rotateHullSpeed;
        [SerializeField] private float _moveSpeed;
        [SerializeField] private float _hp;

        public Tower Tower => _tower.GetComponent<Tower>();
        public Aim Aim => _aim;

        public void Move(float x, float y)
        {
            x *=  _rotateHullSpeed;
            y *=  _moveSpeed * 14;

            _rb.AddRelativeForce(new Vector2(0, y));

            if (y < 0 && x != 0)
            {
                _rb.transform.Rotate(new Vector3(0, 0, x));
            }
            else if (x != 0)
            {
                _rb.transform.Rotate(new Vector3(0, 0, -x));
            }

            _tower.transform.rotation.Normalize();
            _aim.transform.position.Normalize();
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

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.transform.GetComponent<Bulets>())
            {
                float damage = collision.transform.GetComponent<Bulets>().Damage;
                ChekHealth(damage);
            }
        }

        private void ChekHealth(float damage)
        {
            _healthBar.localScale = new Vector3(_healthBar.localScale.x * (1 - damage / _hp), _healthBar.localScale.y, _healthBar.localScale.z);
            _hp -= damage;

            if (_hp <= 0)
            {
                gameObject.SetActive(false);
            }
        }

    }
}
