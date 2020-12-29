using UnityEngine;

namespace Scripts
{
    public class TankControl: MonoBehaviour
    {
        [SerializeField] private TowerRotate _tower;
        [SerializeField] private MoveControl _hull;
        [SerializeField] private CannonShot _cannon;

        [SerializeField] private Transform _towerTransform;
        [SerializeField] private Transform _tankTransform;

        [SerializeField] private float _rotateTowerSpeed;
        [SerializeField] private float _rotateHullSpeed;
        [SerializeField] private float _moveSpeed;


        void FixedUpdate()
        {
            _tower.ChangeDirection(_towerTransform, _rotateTowerSpeed);

            _hull.TankMove(_tankTransform, _towerTransform, _moveSpeed, _rotateHullSpeed);

            if (Input.GetKey(KeyCode.Mouse0))
            {
                _cannon.Fire();
            }
        }
    }
}
