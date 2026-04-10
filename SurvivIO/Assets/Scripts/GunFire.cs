using UnityEngine;

public class GunFire : MonoBehaviour
{
    [SerializeField] private Inventory bulletInventory;

    public void FireButton()
    {
        if (bulletInventory == null) return;

        if (bulletInventory.thisGun == gunTypes.assaultGun)
        {
            bulletInventory.ReduceAmmoAR(); // burst fire
        }
        else
        {
            bulletInventory.ReduceAmmo();    // pistol or shotgun
        }

        //Debug.Log("Fire");
    }
}