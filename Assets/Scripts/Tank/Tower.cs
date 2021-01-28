namespace Scripts
{
    using UnityEngine;

    public class Tower : GraphicWeapons
    {
        [SerializeField] private float _rotateSpeed;

        private Aim _aim;

        private void Awake()
        {
            DistributorLinks distributorLinks = FindObjectOfType<DistributorLinks>();

            _aim = distributorLinks.Aim;
        }

        public override void Movement()
        {
            _aim.SetVisibility(false);

            Vector3 aimTarget = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3 aimDir = aimTarget - transform.position;

            aimDir.z = transform.up.z;
            aimDir = aimDir.normalized;

            transform.up = Vector3.MoveTowards(transform.up, aimDir, _rotateSpeed * Time.fixedDeltaTime);
        }
    }
}
