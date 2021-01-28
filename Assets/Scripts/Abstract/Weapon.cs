namespace Scripts
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public abstract class Weapon : MonoBehaviour
    {
        private bool flag;
        [SerializeField] private float _delay;
        [SerializeField] private float _maxAmmoCount;
        [SerializeField] private float _reloadingTime;

        [SerializeField] private GameObject _prefabBullet;
        [SerializeField] private int _bulletCount;
        [SerializeField] private List<GameObject> _bulets = new List<GameObject>();

        private GraphicWeapons _graphicWeapons;
        private PullManager _pull;
        private UIManager _uI;

        protected float Delay { get => _delay; }
        protected float AmmoCount { get; set; }
        protected float TimeAction { get; set; }

        protected GraphicWeapons GraphicWeapons { set => _graphicWeapons = value; }
        protected Tower Tower { get; set; }
        protected Aim Aim { get; set; }

        private void Initialized(Tower tower, Aim aim, PullManager pull, UIManager uIManager)
        {
            Tower = tower;
            Aim = aim;
            _pull = pull;
            _uI = uIManager;
        }

        private void Awake()
        {
            DistributorLinks distributorLinks = FindObjectOfType<DistributorLinks>();

            Initialized(distributorLinks.Tower,
                        distributorLinks.Aim,
                        distributorLinks.Pull,
                        distributorLinks.UI);

            _pull.InitialCreation(_bulets, _prefabBullet, _bulletCount);

            AmmoCount = _maxAmmoCount;

            SelectGraphicWeapon();
        }

        private IEnumerator Reloading()
        {
            yield return new WaitForSeconds(_reloadingTime);

            AmmoCount = _maxAmmoCount;
        }

        public void ChekAmmo()
        {
            if (AmmoCount > 0)
            {
                _uI.SetTextAmmo(AmmoCount.ToString());
                flag = true;
            }
            else if(flag)
            {
                _uI.SetTextAmmo("  Reloading...");
                flag = false;
                StartCoroutine(Reloading());
            }
        }

        public void Controll()
        {
            if (TimeAction > 0)
            {
                TimeAction -= Time.deltaTime;
            }

            _graphicWeapons.Movement();
        }

        public abstract void Fire();

        protected GameObject GetBullet()
        {
            return _pull.GetPulledObject(_bulets, _prefabBullet);
        }

        protected abstract void SelectGraphicWeapon();
    }
}
