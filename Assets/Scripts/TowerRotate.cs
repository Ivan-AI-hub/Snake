using UnityEngine;
namespace Scripts
{
    public class TowerRotate : MonoBehaviour
    {

        public void ChangeDirection(Transform Tower, float Speed)
        {

            Vector3 aimTarget = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3 aimDir = aimTarget - transform.position;

            aimDir.z = Tower.up.z;
            aimDir = aimDir.normalized;

            Tower.up = Vector3.MoveTowards(Tower.up, aimDir, Speed * Time.fixedDeltaTime);

        }

    }
}
