namespace Scripts
{
    using UnityEngine;

    public class FlameShot : Weapon
    {
        public override void Fire()
        {
            if (AmmoCount > 0)
            {
                GameObject newBullet = GetBullet();

                if ((object)newBullet != null)
                {
                    newBullet.transform.position = transform.position;
                    newBullet.transform.rotation = transform.rotation;

                    newBullet.transform.SetParent(transform);
                    newBullet.SetActive(true);

                    AmmoCount--;
                }
            }
        }

        protected override void SelectGraphicWeapon()
        {
            GraphicWeapons = Tower;
        }
    }
}