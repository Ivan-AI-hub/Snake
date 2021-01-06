namespace Scripts
{
    using UnityEngine;

    public class CoreMove : Bulets
    {
        private Vector3 _aimPosition;

        protected override void Move()
        {
            transform.position = Vector3.MoveTowards(transform.position, _aimPosition, Speed * Time.fixedDeltaTime);
        }

        protected override bool DestructionCondition()
        {
            if (transform.position == _aimPosition)
            {
                Hide = true;
            }

            return Hide;
        }

        private void OnEnable()
        {
            Transform _aim = DistributorLinks
                                            .Aim
                                            .transform;

            _aimPosition = _aim.position;
        }
    }
}
