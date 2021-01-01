using UnityEngine;

namespace Scripts
{
    public class FireControl : MonoBehaviour
    {
        private GameObject Flame;

        private void Awake()
        {
            Flame = GameObject.FindGameObjectWithTag("Flame");
        }

        private void FixedUpdate()
        {
            transform.position = Flame.transform.position;
            transform.rotation = Flame.transform.rotation;

            if (!Input.GetKey(KeyCode.Mouse0))
            {
                gameObject.SetActive(false);
            }
        }
    }
}
