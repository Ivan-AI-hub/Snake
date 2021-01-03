namespace Scripts
{
    using UnityEngine;

    public class BuletMove : Bulets
    {
        protected override void Move()
        {
            transform.Translate(new Vector3(0, Speed * Time.fixedDeltaTime));
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