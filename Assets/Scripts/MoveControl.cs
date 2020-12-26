using UnityEngine;

namespace Scripts
{
    public class MoveControl : MonoBehaviour
    {
        [SerializeField] private Transform _player;
        [SerializeField] private GameObject _camera;
        [SerializeField] private Rigidbody2D rb;

        [SerializeField] private float _speed = 3f;

        private void FixedUpdate()
        {
            Move();
        }

        private void Move()
        {
            if (Input.anyKey)
            {
                float x = Input.GetAxis("Horizontal") * _speed;
                float y = Input.GetAxis("Vertical") * _speed;
                rb.AddForce(new Vector2(x, y));
            }
        }
    }
}
