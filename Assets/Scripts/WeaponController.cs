using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : BaseObject
{
    private int _currWeaponIndex = 0;

    protected override void Awake()
    {
        base.Awake();
        SelectWeapon();
    }

    void Update()
    {
        if (Input.GetAxis("Mouse ScrollWheel") > 0f || Input.GetKeyDown(KeyCode.X))
        {
            if (_currWeaponIndex == transform.childCount - 1)
            {
                _currWeaponIndex = 0;
            }
            else
            {
                _currWeaponIndex++;
            }
            SelectWeapon();
        }
        else if (Input.GetAxis("Mouse ScrollWheel") < 0f || Input.GetKeyDown(KeyCode.Z))
        {
            if (_currWeaponIndex == 0)
            {
                _currWeaponIndex = transform.childCount - 1;
            }
            else
            {
                _currWeaponIndex--;
            }
            SelectWeapon();
        }
    }

    private void SelectWeapon()
    {
        int i = 0;
        foreach (Transform weapon in _GOTransform)
        {
            if (i == _currWeaponIndex)
            {
                weapon.gameObject.SetActive(true);
            }
            else
            {
                weapon.gameObject.SetActive(false);
            }
            i++;
        }
    }
}
