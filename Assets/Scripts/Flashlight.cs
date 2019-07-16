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

    private UIController uiController;

    void Start()
    {
        _light = GetComponentInChildren<Light>();
        _lightMat = GetMaterial;
        uiController = GetComponent<UIController>();
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
                ActiveFlashlight(false);
            }
        }
        // Добавление логики для фонарика
        else if (currTime > 0)
        {
            currTime -= Time.deltaTime;
        }

        if (uiController)
        {
            float chargePercents = 100 - ((currTime / timeout) * 100);
            uiController.BroadcastMessage("onFlashlightChargeChanged", chargePercents);
        }
    }
}
