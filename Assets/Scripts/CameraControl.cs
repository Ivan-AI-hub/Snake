namespace Scripts
{
    using UnityEngine;

    public class CameraControl : MonoBehaviour
    {
        [SerializeField] private float _speed = 8;
        [SerializeField] private Vector3 _offsetPosition = new Vector3(0, 0, -1);

        private Transform _playerTransform;

        private void Awake()
        {
            DistributorLinks _distributorLinks = FindObjectOfType<DistributorLinks>();
            _playerTransform = _distributorLinks.PlayerTank.transform;
        }
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
