using System.Collections.Generic;
using UnityEngine;

namespace Scripts
{
    public class PullManager : MonoBehaviour
    {
        [SerializeField] private GameObject _prefabBulletCannon;
        [SerializeField] private List<GameObject> _buletsCannon = new List<GameObject>();
        [SerializeField] private int _bulletCannonCount = 10;

        [SerializeField] private GameObject _prefabBulletMortal;
        [SerializeField] private List<GameObject> _buletsMortar = new List<GameObject>();
        [SerializeField] private int _bulletMortarCount = 10;

        [SerializeField] private GameObject _prefabFuelFlamethrower;
        [SerializeField] private List<GameObject> _fuelFlamethrower = new List<GameObject>();
        private readonly int __fuelFlamethrowerCount = 1;

        [SerializeField] private bool _willGrow = false;

        private void Awake()
        {

            initialCreation(_fuelFlamethrower, _prefabFuelFlamethrower, __fuelFlamethrowerCount);
            initialCreation(_buletsCannon, _prefabBulletCannon, _bulletCannonCount);
            initialCreation(_buletsMortar, _prefabBulletMortal, _bulletMortarCount);

        }

        private void initialCreation(List<GameObject> NameList, GameObject Prefab, int Count)
        {
            for (int i = 0; i <Count; i++)
            {
                CreateBullet(NameList, Prefab);
            }
        }

        private void CreateBullet(List<GameObject> NameList, GameObject Prefab)
        {

            GameObject obj = Instantiate(Prefab, transform.position, Quaternion.identity);

            obj.SetActive(false);

            NameList.Add(obj);


        }

        public GameObject GetPulledObject(string GunName)
        {
            if (GunName == "Canon")
                return TakeAnalysis(_buletsCannon, _prefabBulletCannon);

            else if (GunName == "Flamethrower")
                return TakeAnalysis(_fuelFlamethrower, _prefabFuelFlamethrower);
            
            else if(GunName == "Mortal")
                return TakeAnalysis(_buletsMortar, _prefabBulletMortal);

            return null;
        }

        private GameObject TakeAnalysis(List<GameObject> NameList, GameObject Prefab)
        {
            for (int i = 0; i < NameList.Count; i++)
            {
                if (!NameList[i].activeSelf)
                {
                    return NameList[i];
                }
            }

            if (_willGrow)
            {
                CreateBullet(NameList, Prefab);
            }

            return null;
        }

        public void Hide(GameObject obj)
        {
            obj.SetActive(false);
        }


    }
}
