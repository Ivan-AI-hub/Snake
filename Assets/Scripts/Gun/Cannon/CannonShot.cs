using UnityEngine;

namespace Scripts
{
    public class CannonShot : MonoBehaviour
    {

        private PullManager _pull;
        
        private float _pause = 0;

        private void Awake()
        {
            _pull = GameObject.FindGameObjectWithTag("Pull").GetComponent<PullManager>();
        }

        public void Fire()
        {
            if (_pause <= 0)
            {
                GameObject newBullet = _pull.GetPulledObject("Canon");

                if (newBullet != null)
                {

                    newBullet.transform.position = transform.position;
                    newBullet.transform.rotation = transform.rotation;

                    newBullet.SetActive(true);
                }

                _pause = 0.5f;
            }
        }

        private void FixedUpdate()
        {
            if (_pause > 0)
            {
                _pause = _pause - 1 * Time.deltaTime;
            }
        }

    }
}