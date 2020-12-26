using UnityEngine;

namespace Scripts {

    public class CameraMove : MonoBehaviour
    {
        [SerializeField] private Transform _playerTransform;
        [SerializeField] private Transform _selfTransform;

        [SerializeField] private float _speed;
        [SerializeField] private Vector3 _offsetPosition;

        private void FixedUpdate()
        {
            Move(_playerTransform, _speed);
        }

        private void Move(Transform Object, float Speed)
        {
            _selfTransform.position = Vector3.Lerp(_selfTransform.position, Object.position + _offsetPosition, Speed * Time.deltaTime);
        }

    }

}
