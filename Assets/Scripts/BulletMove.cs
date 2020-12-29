using UnityEngine;

namespace Scripts
{
    public class BulletMove : MonoBehaviour
    {

        [SerializeField] private GameObject _selfObject;

        [SerializeField] private float _speed;

        private void OnEnable()
        {
            Invoke("Hide", 5f);
        }

        private void Hide()
        {
            _selfObject.SetActive(false);
        }

        private void FixedUpdate()
        {
            _selfObject.transform.Translate(0, _speed * Time.deltaTime, 0);
        }

    }
}
