using UnityEngine;

namespace Scripts {

    public class CameraMove : MonoBehaviour
    {
        [SerializeField] private Transform Player;
        [SerializeField] private Transform SelfTransform;

        [SerializeField] private float Speed;
        [SerializeField] private Vector3 offsetPosition;

        private void FixedUpdate()
        {
            Move(Player, Speed);
        }

        private void Move(Transform Object, float Speed)
        {
            SelfTransform.position = Vector3.Lerp(SelfTransform.position, Object.position + offsetPosition, Speed * Time.deltaTime);
        }

    }

}
