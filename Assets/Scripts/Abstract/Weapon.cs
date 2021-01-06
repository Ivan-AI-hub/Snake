namespace Scripts
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public abstract class Weapon : MonoBehaviour
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

        private GraphicWeapons _graphicWeapons;

        protected GraphicWeapons GraphicWeapons
        {
            set { _graphicWeapons = value; }
        }

        protected DistributorLinks DistributorLinks => _distributorLinks;

        protected float TimeAction
        {
            get { return _timeBetweenAction; }
            set { _timeBetweenAction = value; }
        }

        protected float Delay => _delay;

        protected float AmmoCount
        {
            get { return _ammoCount; }
            set { _ammoCount = value; }
        }


        public abstract void Fire();

        protected abstract void SelectGraphicWeapon();

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

            SelectGraphicWeapon();
        }

        public void Controll()
        {
            if (_timeBetweenAction > 0)
            {
                _timeBetweenAction -= Time.deltaTime;
            }

            _graphicWeapons.Movement();
        }

        protected GameObject GetBullet()
        {
            return _distributorLinks.Pull.GetPulledObject(_bulets, _prefabBullet);
        }
    }
}
