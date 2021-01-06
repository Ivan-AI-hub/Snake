namespace Scripts
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class Weapon : MonoBehaviour
    {
        [SerializeField] private float _delay;
        [SerializeField] private float _maxAmmoCount;
        [SerializeField] private float _reloadingTime;

        [SerializeField] private GameObject _prefabBullet;
        [SerializeField] private int _bulletCount;
        [SerializeField] private List<GameObject> _bulets = new List<GameObject>();

        private float _ammoCount;

        private DistributorLinks _distributorLinks;

        private float _timeBetweenAction;

        public void Fire()
        {
            if (_timeBetweenAction <= 0 && _ammoCount > 0)
            {
                GameObject newBullet = GetBullet();

                if (newBullet != null)
                {
                    newBullet.transform.position = transform.position;
                    newBullet.transform.rotation = transform.rotation;

                    newBullet.SetActive(true);

                    _ammoCount--;

                    _timeBetweenAction = _delay;

                    if (_delay == 0)
                    {
                        newBullet.transform.SetParent(transform, true);
                    }
                }
            }
        }

        public void ChekAmmo()
        {
            if (_ammoCount > 0)
            {
                _distributorLinks.UI.SetTextAmmo(_ammoCount.ToString());
            }
            else
            {
                _distributorLinks.UI.SetTextAmmo("  Reloading...");

                StartCoroutine(Reloading());
            }
        }

        private IEnumerator Reloading()
        {
            yield return new WaitForSeconds(_reloadingTime);

            _ammoCount = _maxAmmoCount;
        }

        private void Awake()
        {
            _distributorLinks = FindObjectOfType<DistributorLinks>();

            _distributorLinks.Pull.InitialCreation(_bulets, _prefabBullet, _bulletCount);

            _ammoCount = _maxAmmoCount;
        }

        private void FixedUpdate()
        {
            if (_timeBetweenAction > 0)
            {
                _timeBetweenAction -= Time.deltaTime;
            }
        }

        private GameObject GetBullet()
        {
            return _distributorLinks.Pull.GetPulledObject(_bulets, _prefabBullet);
        }
    }
}
