using UnityEngine;

namespace Scripts
{
    public class MoveControl : MonoBehaviour
    {

        public void TankMove(Transform Tank, Transform Tower, float Speed, float RotateHullSpeed)
        {
            if (Input.anyKey)
            {
                float x = Input.GetAxis("Horizontal") * Speed;
                float y = Input.GetAxis("Vertical") * Speed;

                Tank.Translate(0, y * Time.deltaTime, 0);

                Tank.Rotate(0, 0, RotateHullSpeed * -x / 4);

                Tower.rotation.Normalize();
            }
        }


        public void CameraMove(Transform Camera,Transform Tank, float Speed, Vector3 OffsetPosition)
        {
            Camera.position = Vector3.Lerp(Camera.position, Tank.position + OffsetPosition, Speed * Time.deltaTime);
        }


    }
}
