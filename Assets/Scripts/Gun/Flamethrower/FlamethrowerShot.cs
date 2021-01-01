using UnityEngine;

namespace Scripts
{
    public class FlamethrowerShot : MonoBehaviour
    {
        private PullManager _pull;

        private void Awake()
        {
            _pull = GameObject.FindGameObjectWithTag("Pull").GetComponent<PullManager>();
        }

        public void Fire()
        {

                GameObject newBullet = _pull.GetPulledObject("Flamethrower");

                if (newBullet != null)
                {

                    newBullet.transform.position = transform.position;
                    newBullet.transform.rotation = transform.rotation;

                    newBullet.SetActive(true);
                }

        }


    }
}
