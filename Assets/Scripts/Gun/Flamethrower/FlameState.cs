namespace Scripts
{
    using UnityEngine;

    public class FlameState : Bulets
    {
        protected override void Move()
        {
        }

        protected override bool DestructionCondition()
        {
            if (!Input.GetKey(KeyCode.Mouse0))
            {
                Hide = true;
            }

            return Hide;
        }
    }
}