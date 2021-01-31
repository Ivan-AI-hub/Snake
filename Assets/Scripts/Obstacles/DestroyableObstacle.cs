namespace Scripts
{
    using UnityEngine;

    public class DestroyableObstacle : MonoBehaviour
    {
        [SerializeField] private float _hp;

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.transform.GetComponent<Bulets>())
            {
                float damage = collision.transform.GetComponent<Bulets>().Damage;
                _hp -= damage;

                if (_hp <= 0)
                {
                    gameObject.SetActive(false);
                }
            }
        }
    }
}