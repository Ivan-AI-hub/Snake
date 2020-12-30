using UnityEngine;

namespace Scripts
{

    public class CameraControl : MonoBehaviour
    {
        [SerializeField] private Transform _playerTransform;

        [SerializeField] private float _speed;
        [SerializeField] private Vector3 _offsetPosition;

        private void FixedUpdate()
        {
            CameraMove(transform, _playerTransform, _speed, _offsetPosition);
        }

        private void CameraMove(Transform Camera, Transform Tank, float Speed, Vector3 OffsetPosition)
        {
            Camera.position = Vector3.Lerp(Camera.position, Tank.position + OffsetPosition, Speed * Time.deltaTime);
        }

    }

}
