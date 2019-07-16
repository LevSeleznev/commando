using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : BaseObject
{
    private KeyCode control = KeyCode.F;
    private float timeout = 120;
    private Light _light;

    private float currTime;
    private float currReloadTime;
    Material _lightMat;

    void Start()
    {
        _light = GetComponentInChildren<Light>();
        _lightMat = GetMaterial;
    }

    private void ActiveFlashlight(bool val)
    {
        _light.enabled = val;
    }

    void Update()
    {
        if (Input.GetKeyDown(control) && !_light.enabled)
        {
            ActiveFlashlight(true);
        }
        else if (Input.GetKeyDown(control) && _light.enabled)
        {
            ActiveFlashlight(false);
        }

        if (_light.enabled)
        {
            currTime += Time.deltaTime;
            if (currTime > timeout)
            {
                currTime = 0;
                ActiveFlashlight(false);
            }
        }
    }
}
