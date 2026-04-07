using UnityEngine;

public class GunHandle : MonoBehaviour
{
    [SerializeField] private gunTypes thisGun;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerMovement player = collision.GetComponent<PlayerMovement>();
        if (player == null) return;

        Inventory inv = collision.GetComponent<Inventory>();
        if (inv == null) return;

        if (inv.currentGun == null)
        {
            EquipGun(inv);
        }
        else if (inv.holsteredGun == null)
        {
            HolsterGun(inv);
        }
        else
        {
            EquipGun(inv);
        }

        Destroy(gameObject);
    }

    void EquipGun(Inventory inv)
    {
        if (thisGun == gunTypes.pistolGun)
            inv.EquipPistol();
        else if (thisGun == gunTypes.shotgunGun)
            inv.EquipShotgun();
        else if (thisGun == gunTypes.assaultGun)
            inv.EquipAssault();
    }

    void HolsterGun(Inventory inv)
    {
        if (thisGun == gunTypes.pistolGun)
            inv.HolsterPistol();
        else if (thisGun == gunTypes.shotgunGun)
            inv.HolsterShotgun();
        else if (thisGun == gunTypes.assaultGun)
            inv.HolsterAssault();
    }
}