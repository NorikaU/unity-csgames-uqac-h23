using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponManager : MonoBehaviour
{
    public Weapon[] weapons; // an array of weapon objects
    public int activeWeaponIndex = 0; // the index of the currently active weapon

    // Start is called before the first frame update
    void Start()
    {
        weapons[1].gameObject.SetActive(false);
        weapons[0].gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        // switch weapons using the number keys
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if(!weapons[activeWeaponIndex].isReloading) {
                SetActiveWeapon(0);
            }
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if(!weapons[activeWeaponIndex].isReloading) {
                SetActiveWeapon(1);
            }
        }
    }

    void SetActiveWeapon(int index)
    {
        // disable the currently active weapon
        weapons[activeWeaponIndex].gameObject.SetActive(false);

        // set the new active weapon index
        activeWeaponIndex = index;

        // enable the new active weapon
        weapons[activeWeaponIndex].gameObject.SetActive(true);
    }
}