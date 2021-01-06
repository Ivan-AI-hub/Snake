namespace Scripts
{
    using UnityEngine;

    public class Aim : GraphicWeapons
    {
        [SerializeField] private float _speed;

        public override void Movement()
        {
            if (gameObject.activeSelf)
            {
                Vector3 aimTarget = Camera.main.ScreenToWorldPoint(Input.mousePosition);

                transform.position = Vector3.MoveTowards(transform.position, aimTarget + Vector3.forward, _speed * Time.fixedDeltaTime);
            }
            else
            {
                transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);

                VisibilityChange(true);
            }
        }

        public void VisibilityChange(bool value)
        {
            gameObject.SetActive(value);
        }
    }
}
