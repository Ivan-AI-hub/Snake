namespace Scripts
{
    using UnityEngine;

    public class BuletMove : Bulets
    {
        [SerializeField] private Rigidbody2D _rb;

        protected override void Move()
        {
            gameObject.transform.Translate(new Vector3(0, Speed * Time.fixedDeltaTime));
        }

        protected override bool DestructionCondition()
        {
            return Hide;
        }

        private void OnCollisionEnter2D()
        {
            Hide = true;
        }
    }
}