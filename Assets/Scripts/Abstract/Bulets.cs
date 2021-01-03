namespace Scripts
{
    using UnityEngine;

    public abstract class Bulets : MonoBehaviour
    {
        [SerializeField] private float _speed;

        private bool _hide = false;

        private PullManager _pull;

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
            _pull = FindObjectOfType<PullManager>();
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
            _pull.Hide(gameObject);
            _hide = false;
        }
    }
}