namespace Scripts
{
    using UnityEngine;

    public class Tower : GraphicWeapons
    {
        [SerializeField] private float _rotateSpeed;

        public override void Movement()
        {
            Vector3 aimTarget = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3 aimDir = aimTarget - transform.position;

            aimDir.z = transform.up.z;
            aimDir = aimDir.normalized;

            transform.up = Vector3.MoveTowards(transform.up, aimDir, _rotateSpeed * Time.fixedDeltaTime);
        }
    }
}
