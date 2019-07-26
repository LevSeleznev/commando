using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class UIController : MonoBehaviour
{
    [SerializeField] private Text chargeLabel;
    [SerializeField] private Text bulletCountLabel;

    private void onFlashlightChargeChanged(int charge)
    {
        chargeLabel.text = charge.ToString() + "%";
    }

    private void OnBulletCountChanged(int bulletCount)
    {
        bulletCountLabel.text = bulletCount.ToString();
    }
}
