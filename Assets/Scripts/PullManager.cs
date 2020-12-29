using System.Collections.Generic;
using UnityEngine;

namespace Scripts
{
    public class PullManager : MonoBehaviour
    {
        [SerializeField] private GameObject _prefab;
        [SerializeField] private Transform _parentTransform;
        [SerializeField] private List<GameObject> _bullets = new List<GameObject>();
        [SerializeField] private int _bulletCount = 10;
        [SerializeField] private bool _willGrow = false;

        private void Awake()
        {
            for (int i = 0; i < _bulletCount; i++)
            {
                CreateBullet();
            }
        }

        private GameObject CreateBullet()
        {

            GameObject obj = (GameObject)Instantiate(_prefab, _parentTransform.position, Quaternion.identity);

            obj.SetActive(false);
            _bullets.Add(obj);

            return obj;

        }

        public GameObject GetPulledObject()
        {
            for (int i = 0; i < _bulletCount; i++)
            {
                if (!_bullets[i].activeSelf)
                {
                    return _bullets[i];
                }
            }

            if (_willGrow)
            {
                CreateBullet();
            }

            return null;
        }


    }
}
