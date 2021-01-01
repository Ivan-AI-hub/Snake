﻿using UnityEngine;

namespace Scripts
{

    public class MortalShot : MonoBehaviour
    {
        private PullManager _pull;

        private float Pause = 0;

        private void Awake()
        {
            _pull = GameObject.FindGameObjectWithTag("Pull").GetComponent<PullManager>();
        }

        public void Fire()
        {
            if (Pause <= 0)
            {
                GameObject newBullet = _pull.GetPulledObject("Mortal");

                if (newBullet != null)
                {

                    newBullet.transform.position = transform.position;
                    newBullet.transform.rotation = transform.rotation;

                    newBullet.SetActive(true);
                }

                Pause = 2f;
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
