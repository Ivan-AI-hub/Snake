namespace Scripts
{
    using UnityEngine;

    public class CameraControl : MonoBehaviour
    {
        [SerializeField] private Transform _playerTransform;

        [SerializeField] private float _speed;
        [SerializeField] private Vector3 _offsetPosition;

        private void FixedUpdate()
        {
            CameraMove(transform, _playerTransform, _speed, _offsetPosition);
        }

        private void CameraMove(Transform camera, Transform tank, float speed, Vector3 offsetPosition)
        {
            camera.position = Vector3.Lerp(camera.position, tank.position + offsetPosition, speed * Time.deltaTime);
        }
    }
}
