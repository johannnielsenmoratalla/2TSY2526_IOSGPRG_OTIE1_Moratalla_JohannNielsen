using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Inventory : MonoBehaviour
{
    [SerializeField] private Transform nozzle;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private TextMeshProUGUI gunText;

    public TextMeshProUGUI reloadingText;

    public gunTypes thisGun;

    public int pistolAmmo;
    public int shotgunAmmo;
    public int assaultAmmo;

    public TextMeshProUGUI PistolAmmoDisplay;
    public TextMeshProUGUI ShotgunAmmoDisplay;
    public TextMeshProUGUI ARAmmoDsiplay;

    public int pistolClip;
    public int shotgunClip;
    public int assaultClip;

    public GameObject pistolPrefab;
    public GameObject shotgunPrefab;
    public GameObject assaultPrefab;

    public GameObject currentGun;
    public GameObject holsteredGun;
    public GameObject character;

    public Transform gunPosition;

    private bool canShoot = true;

    public bool hasPistol = false;
    public bool hasShotgun = false;
    public bool hasAssault = false;


    private void Update()
    {
        PistolAmmoDisplay.text = $" {pistolClip} / {pistolAmmo}";
        ShotgunAmmoDisplay.text = $" {shotgunClip} / {shotgunAmmo}";
        ARAmmoDsiplay.text = $" {assaultClip} / {assaultAmmo}";
    }
    public void HolsterAssault()
    {
        holsteredGun = assaultPrefab;
    }
    public void HolsterPistol()
    {
        holsteredGun = pistolPrefab;
    }
    public void HolsterShotgun()
    {
        holsteredGun = shotgunPrefab;
    }

    public void EquipPistol()
    {
        if (currentGun != null) Destroy(currentGun);

        currentGun = Instantiate(pistolPrefab, gunPosition.position, gunPosition.rotation);
        currentGun.transform.parent = character.transform;

        thisGun = gunTypes.pistolGun;
        gunText.text = "pistol";
    }

    public void EquipShotgun()
    {
        if (currentGun != null) Destroy(currentGun);

        currentGun = Instantiate(shotgunPrefab, gunPosition.position, gunPosition.rotation);
        currentGun.transform.parent = character.transform;

        thisGun = gunTypes.shotgunGun;
        gunText.text = "shotgun";
    }

    public void EquipAssault()
    {
        if (currentGun != null) Destroy(currentGun);

        currentGun = Instantiate(assaultPrefab, gunPosition.position, gunPosition.rotation);
        currentGun.transform.parent = character.transform;

        thisGun = gunTypes.assaultGun;
        gunText.text = "assault";
    }

    public void ReduceAmmo()
    {
        if (currentGun != null)
        {
            if (thisGun == gunTypes.pistolGun && pistolClip > 0)
            {
                StartCoroutine(ShootWithCooldownPistol(0.5f));
            }
            else if (thisGun == gunTypes.pistolGun && pistolClip <= 0)
            {
                if (pistolAmmo <= 0)
                {
                    StartCoroutine(ShowMessage("NO AMMO", 1.5f));
                }
                else
                {
                    StartCoroutine(PistolReload(2.0f));
                }
            }

            if (thisGun == gunTypes.shotgunGun && shotgunClip > 0)
            {
                StartCoroutine(ShootWithCooldownShotGun(2.0f));
            }
            else if (thisGun == gunTypes.shotgunGun && shotgunClip <= 0)
            {
                if (shotgunAmmo <= 0)
                {
                    StartCoroutine(ShowMessage("NO AMMO", 1.5f));
                }
                else
                {
                    StartCoroutine(ShotgunReload(2.7f));
                }
            }
        }
    }
    public void ReduceAmmoAR()
    {
        if (currentGun != null && thisGun == gunTypes.assaultGun)
        {
            if (assaultClip > 0)
            {
                StartCoroutine(BurstFire(3, 0.08f));
            }
            else
            {
                if (assaultAmmo <= 0)
                {
                    StartCoroutine(ShowMessage("NO AMMO", 1.5f));
                }
                else
                {
                    StartCoroutine(AssaultReload(2.3f));
                }
            }
        }
    }

    private IEnumerator BurstFire(int burstCount, float delayBetweenShots)
    {
        if (!canShoot) yield break;

        canShoot = false;

        for (int i = 0; i < burstCount; i++)
        {
            if (assaultClip <= 0)
                break;

            assaultClip--;

            Instantiate(bulletPrefab, nozzle.position, nozzle.rotation);

            yield return new WaitForSeconds(delayBetweenShots);
        }

        if (assaultClip <= 0)
        {
            StartCoroutine(AssaultReload(2.3f));
        }

        yield return new WaitForSeconds(0.2f);

        canShoot = true;
    }

    private IEnumerator ShootWithCooldownPistol(float cooldown)
    {
        if (canShoot)
        {
            canShoot = false;

            pistolClip--;
            Instantiate(bulletPrefab, nozzle.position, nozzle.rotation);

            yield return new WaitForSeconds(cooldown);

            canShoot = true;
        }
    }

    private IEnumerator ShootWithCooldownShotGun(float cooldown)
    {
        if (canShoot)
        {
            canShoot = false;

            float initialRotation = -30 / 2f;

            for (int i = 0; i <= 8; i++)
            {
                float currentRotation = initialRotation + i * 10f;

                Quaternion bulletRotation = Quaternion.Euler(0, 1, currentRotation);
                Quaternion spawnRotation = nozzle.rotation * bulletRotation;

                Instantiate(bulletPrefab, nozzle.position, spawnRotation);

                yield return null;
            }

            shotgunClip--;

            yield return new WaitForSeconds(cooldown);

            canShoot = true;
        }
    }

    private IEnumerator PistolReload(float cooldown)
    {
        if (canShoot)
        {
            canShoot = false;

            reloadingText.text = "Reloading...";
            reloadingText.gameObject.SetActive(true);

            yield return new WaitForSeconds(cooldown);

            if (pistolAmmo >= 15)
            {
                pistolClip = 15;
                pistolAmmo -= 15;
            }
            else
            {
                pistolClip = pistolAmmo;
                pistolAmmo = 0;
            }

            reloadingText.gameObject.SetActive(false);

            canShoot = true;
        }
    }

    private IEnumerator ShotgunReload(float cooldown)
    {
        if (canShoot)
        {
            canShoot = false;

            reloadingText.text = "Reloading...";
            reloadingText.gameObject.SetActive(true);

            yield return new WaitForSeconds(cooldown);

            if (shotgunAmmo >= 15)
            {
                shotgunClip = 15;
                shotgunAmmo -= 15;
            }
            else
            {
                shotgunClip = shotgunAmmo;
                shotgunAmmo = 0;
            }

            reloadingText.gameObject.SetActive(false);

            canShoot = true;
        }
    }

    private bool isReloading = false;

    private IEnumerator AssaultReload(float cooldown)
    {
        if (isReloading) yield break;
        
        isReloading = true;
        canShoot = false;

        reloadingText.text = "Reloading...";
        reloadingText.gameObject.SetActive(true);

        yield return new WaitForSeconds(cooldown);

        if (assaultAmmo >= 15)
        {
            assaultClip = 15;
            assaultAmmo -= 15;
        }
        else
        {
            assaultClip = assaultAmmo;
            assaultAmmo = 0;
        }

        reloadingText.gameObject.SetActive(false);

        canShoot = true;
        isReloading = false;
    }

    public void OnPistolButton()
    {
        if (!hasPistol) return;

        EquipPistol();
    }

    public void OnShotgunButton()
    {
        if (!hasShotgun) return;

        EquipShotgun();
    }

    public void OnAssaultButton()
    {
        if (!hasAssault) return;

        EquipAssault();
    }

    IEnumerator ShowMessage(string message, float duration)
    {
        reloadingText.text = message;
        reloadingText.gameObject.SetActive(true);

        yield return new WaitForSeconds(duration);

        reloadingText.gameObject.SetActive(false);
    }
}