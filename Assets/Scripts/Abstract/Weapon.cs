namespace Scripts
{
    using System.Collections.Generic;
    using UnityEngine;

    public abstract class Weapon : MonoBehaviour
    {
        [SerializeField] private float _delay;
        [SerializeField] private GameObject _prefabBullet;
        [SerializeField] private int _bulletCount;
        [SerializeField] private List<GameObject> _bulets = new List<GameObject>();

        private PullManager _pull;

        private float _damage;
        private float _timeBetweenAction;

        protected float Deley => _delay;

        public void DesigShots(float delay)
        {
            if (_timeBetweenAction <= 0)
            {
                GameObject newBullet = GetBullet();

                if (newBullet != null)
                {
                    newBullet.transform.position = transform.position;
                    newBullet.transform.rotation = transform.rotation;

                    newBullet.SetActive(true);
                }

                _timeBetweenAction = delay;
            }
        }

        public void ShotTemplate()
        { 
            GameObject newBullet = GetBullet();

            if (newBullet != null)
            {
                newBullet.transform.position = transform.position;
                newBullet.transform.rotation = transform.rotation;

                newBullet.transform.SetParent(transform, true);
                newBullet.SetActive(true);
            }
        }

        public abstract void Fire();

        protected void Awake()
        {
            _pull = FindObjectOfType<PullManager>();

            _pull.InitialCreation(_bulets, _prefabBullet, _bulletCount);
        }

        protected void FixedUpdate()
        {
            if (_timeBetweenAction > 0)
            {
                _timeBetweenAction = _timeBetweenAction - Time.deltaTime;
            }
        }

        protected GameObject GetBullet()
        {
            return _pull.GetPulledObject(_bulets, _prefabBullet);
        }
    }
}
