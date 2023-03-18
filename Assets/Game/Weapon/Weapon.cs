using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using StarterAssets;

public class Weapon : MonoBehaviour
{
    private StarterAssetsInputs _input;
    public GameObject bulletPreFab; // bullet object
    public GameObject bulletPoint; // location of bullet 
    public float bulletSpeed = 1000f; // speed of bullet

    public int maxAmmoCount = 30;
    private int currentAmmoCount = 30;

    public float reloadTime = 1f;
    public bool isReloading = false;

    public Text ammoText; // reference to the UI Text element

    // Start is called before the first frame update
    void Start()
    {
        _input = transform.root.GetComponent<StarterAssetsInputs>();
        currentAmmoCount = maxAmmoCount;
    }

    // Update is called once per frame
    void Update()
    {
        if (_input.shoot && currentAmmoCount > 0 && !isReloading)
        {
            Shoot();
            currentAmmoCount--;
            _input.shoot = false;
        }

        if (currentAmmoCount == 0 && !isReloading)
        {
            StartCoroutine(Reload());
        }

        // Update the ammo text
        if (isReloading)
        {
            ammoText.text = "Reloading...";
        }
        else
        {
            ammoText.text = "Ammo: " + currentAmmoCount.ToString() + "/" + maxAmmoCount.ToString();
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPreFab, bulletPoint.transform.position, transform.rotation);
        bullet.GetComponent<Rigidbody>().AddForce(transform.forward * bulletSpeed);
        Destroy(bullet, 3f); // erase bullet after its use is finished
    }

    IEnumerator Reload()
    {
        isReloading = true;
        yield return new WaitForSeconds(reloadTime);
        currentAmmoCount = maxAmmoCount;
        isReloading = false;
    }
}