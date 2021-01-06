namespace Scripts
{
    using UnityEngine;

    public abstract class Bulets : MonoBehaviour
    {
        [SerializeField] private float _speed;

        private bool _hide = false;

        private DistributorLinks _distributorLinks;

        protected DistributorLinks DistributorLinks => _distributorLinks;

        protected float Speed => _speed;

        protected bool Hide
        {
            get { return _hide; }
            set { _hide = value; }
        }

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
            _hide = false;
        }
    }
}