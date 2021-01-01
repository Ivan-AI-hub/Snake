using UnityEngine;

namespace Scripts
{
    public class TankControl : MonoBehaviour
    {

        [SerializeField] private CannonShot _cannon;
        [SerializeField] private FlamethrowerShot _flamethrower;
        [SerializeField] private MortalShot _mortal;

        [SerializeField] private Transform _towerTransform;

        [SerializeField] private Transform _aim;

        [SerializeField] private float _rotateTowerSpeed;
        [SerializeField] private float _rotateHullSpeed;
        [SerializeField] private float _moveSpeed;


        void FixedUpdate()
        {
            //  ChangeDirection(_towerTransform, _rotateTowerSpeed);
            AimControl(_aim, _rotateTowerSpeed);
            TankMove(transform, _towerTransform, _moveSpeed, _rotateHullSpeed);

            if (Input.GetKey(KeyCode.Mouse0))
            {
                _mortal.Fire();
            }
        }

        public void TankMove(Transform Tank, Transform Tower, float Speed, float RotateHullSpeed)
        {

                float x = Input.GetAxis("Horizontal") * Speed;
                float y = Input.GetAxis("Vertical") * Speed;

                Tank.Translate(0, y * Time.fixedDeltaTime, 0);

                if (y<0)
                    Tank.Rotate(0, 0, RotateHullSpeed * x / 4);
                else 
                    Tank.Rotate(0, 0, RotateHullSpeed * -x / 4);

            Tower.rotation.Normalize();

        }

        public void ChangeDirection(Transform Tower, float Speed)
        {

            Vector3 aimTarget = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3 aimDir = aimTarget - Tower.position;

            aimDir.z = Tower.up.z;
            aimDir = aimDir.normalized;

            Tower.up = Vector3.MoveTowards(Tower.up, aimDir, Speed * Time.fixedDeltaTime);
        }

        public void AimControl(Transform Aim, float Speed)
        {
            Vector3 aimTarget = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            Aim.position = Vector3.MoveTowards(Aim.position, aimTarget + Vector3.forward, Speed * Time.fixedDeltaTime);
        }
    }
}
