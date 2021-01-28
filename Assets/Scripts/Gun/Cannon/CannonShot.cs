namespace Scripts
{
    using UnityEngine;

    public class CannonShot : Weapon
    {
        public override void Fire()
        {
            if (TimeAction <= 0 && AmmoCount > 0)
            {
                GameObject newBullet = GetBullet();

                if ((object)newBullet != null)
                {
                    newBullet.transform.position = transform.position;
                    newBullet.transform.rotation = transform.rotation;

                    newBullet.SetActive(true);

                    AmmoCount--;

                    TimeAction = Delay;

                }
            }
        }

        protected override void SelectGraphicWeapon()
        {
            GraphicWeapons = Tower;
        }
    }
}
