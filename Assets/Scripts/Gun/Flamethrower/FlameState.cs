namespace Scripts
{
    using System.Collections;
    using UnityEngine;

    public class FlameState : Bulets
    {
        [SerializeField] private float _timeBeforeDestruction;

        protected override void Move()
        {
        }

        protected override bool DestructionCondition()
        {
            StartCoroutine(Waiting());

            return Hide;
        }

        private IEnumerator Waiting()
        {
            yield return new WaitForSeconds(_timeBeforeDestruction);
            Hide = true;
        }
    }
}