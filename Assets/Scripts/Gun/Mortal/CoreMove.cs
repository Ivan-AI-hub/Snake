namespace Scripts
{
    using UnityEngine;

    public class CoreMove : Bulets
    {
        private Vector3 _aimPosition;
        private bool hit = false;

        protected override void Move()
        {
            transform.position = Vector3.MoveTowards(transform.position, _aimPosition, Speed * Time.fixedDeltaTime);
        }

        protected override bool DestructionCondition()
        {
            if (transform.position == _aimPosition)
            {
                gameObject.GetComponent<CircleCollider2D>().enabled = true;

                if (hit) Hide = true;

                hit = true;
               
            }

            return Hide;
        }

        private void OnEnable()
        {
            Transform _aim = DistributorLinks.Aim.transform;
            _aimPosition = _aim.position;

            hit = false;

            gameObject.GetComponent<CircleCollider2D>().enabled = false;
        }

        private void OnCollisionEnter2D()
        {
            Hide = true;
        }
    }
}
