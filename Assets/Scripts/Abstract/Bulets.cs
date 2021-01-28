namespace Scripts
{
    using UnityEngine;

    public abstract class Bulets : MonoBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] private float _damage;
        private DistributorLinks _distributorLinks;

        protected DistributorLinks DistributorLinks => _distributorLinks;
        protected float Speed => _speed;
        protected bool Hide { get; set; }

        public float Damage => _damage;

        protected abstract void Move();

        protected abstract bool DestructionCondition();

        private void Awake()
        {
            _distributorLinks = FindObjectOfType<DistributorLinks>();
        }

        private void FixedUpdate()
        {
            Move();

            if (DestructionCondition())
            {
                Delete();
            }
        }

        private void Delete()
        {
            _distributorLinks.Pull.Hide(gameObject);
            Hide = false;
        }
    }
}