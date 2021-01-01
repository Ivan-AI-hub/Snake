using UnityEngine;

namespace Scripts
{
    public class CoreMove : MonoBehaviour
    {

        [SerializeField] private float _speed;
        private GameObject Aim;
        private Vector3 _aimPosition;

        private void Awake()
        {
            Aim = GameObject.FindGameObjectWithTag("Aim");
        }

        private void OnEnable()
        {
            _aimPosition = Aim.transform.position;
        }

        private void FixedUpdate()
        {
            transform.position = Vector3.MoveTowards(transform.position, _aimPosition, _speed * Time.fixedDeltaTime);

            if (transform.position == _aimPosition)
            {
                PullManager _pull = GameObject.FindGameObjectWithTag("Pull").GetComponent<PullManager>();

                _pull.Hide(gameObject);
            }
        }

    }
}