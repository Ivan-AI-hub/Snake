using UnityEngine;

namespace Scripts {

    public class CameraMove : MonoBehaviour
    {
        [SerializeField] private MoveControl _hull;

        [SerializeField] private Transform _tankTransform;
        [SerializeField] private Transform _selfTransform;

        [SerializeField] private float _speed;
        [SerializeField] private Vector3 _offsetPosition;

        private void FixedUpdate()
        {
            _hull.CameraMove(_selfTransform, _tankTransform, _speed, _offsetPosition);
        }

    }

}
