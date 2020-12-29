using UnityEngine;

namespace Scripts 
{
    public class CannonShot : MonoBehaviour
    {

        [SerializeField] private PullManager _pull;
        [SerializeField] private Transform _tower;

        private float Pause = 0;

        public void Fire()
        {
            if (Pause <= 0)
            {
                GameObject newBullet = _pull.GetPulledObject();

                if (newBullet != null)
                {

                    newBullet.transform.rotation = _tower.rotation;
                    newBullet.transform.position = _tower.position;

                    newBullet.SetActive(true);
                }

                Pause = 0.5f;
            }
        }

        private void FixedUpdate()
        {
            if (Pause > 0)
            {
                Pause = Pause - 1 * Time.deltaTime;
            }
        }

    }
}