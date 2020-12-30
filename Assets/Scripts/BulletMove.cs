using UnityEngine;

namespace Scripts
{
    public class BulletMove : MonoBehaviour
    {

        [SerializeField] private float _speed;
        [SerializeField] private Rigidbody2D _rb;

        private void FixedUpdate()
        {
            transform.Translate(new Vector3(0, _speed * Time.fixedDeltaTime));
        }

        private void OnCollisionEnter2D()
        {
            PullManager _pull = GameObject.FindGameObjectWithTag("Pull").GetComponent<PullManager>();

            _pull.Hide(gameObject);
        }

    }
}
