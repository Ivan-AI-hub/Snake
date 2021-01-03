namespace Scripts
{
    using System.Collections.Generic;
    using UnityEngine;

    public class PullManager : MonoBehaviour
    {
        [SerializeField] private bool _willGrow = false;

        public void InitialCreation(List<GameObject> nameList, GameObject prefab, int count)
        {
            for (int i = 0; i < count; i++)
            {
                CreateBullet(nameList, prefab);
            }
        }

        public GameObject GetPulledObject(List<GameObject> nameList, GameObject prefab)
        {
            for (int i = 0; i < nameList.Count; i++)
            {
                if (!nameList[i].activeSelf)
                {
                    nameList[i].transform.SetParent(null);
                    return nameList[i];
                }
            }

            if (_willGrow)
            {
                CreateBullet(nameList, prefab);
            }

            return null;
        }

        public void Hide(GameObject obj)
        {
            obj.SetActive(false);
            obj.transform.SetParent(transform, true);
        }

        private void CreateBullet(List<GameObject> nameList, GameObject prefab)
        {
            GameObject obj = Instantiate(prefab, transform.position, Quaternion.identity);

            Hide(obj);

            nameList.Add(obj);
        }
    }
}
