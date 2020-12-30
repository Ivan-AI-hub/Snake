using System.Collections.Generic;
using UnityEngine;

namespace Scripts
{
    public class PullManager : MonoBehaviour
    {
        [SerializeField] private GameObject _prefab;
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

        private void CreateBullet()
        {

            GameObject obj = Instantiate(_prefab, transform.position, Quaternion.identity);

            obj.SetActive(false);
            _bullets.Add(obj);


        }

        public GameObject GetPulledObject()
        {
            for (int i = 0; i < _bullets.Count; i++)
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

        public void Hide(GameObject obj)
        {
            obj.SetActive(false);
        }


    }
}
