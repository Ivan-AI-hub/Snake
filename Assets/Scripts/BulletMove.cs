using UnityEngine;

namespace Scripts
{
    public class BulletMove : MonoBehaviour
    {

        [SerializeField] private float _speed;

        private void OnEnable()
        {
            Invoke("Hide", 5f);
        }

        private void Hide()
        {
            PullManager _pull = GameObject.FindGameObjectWithTag("Pull").GetComponent<PullManager>();

            _pull.Hide(gameObject);
        }

        private void FixedUpdate()
        {
            transform.Translate(new Vector3(0,_speed*Time.fixedDeltaTime));
        }

    }
}
