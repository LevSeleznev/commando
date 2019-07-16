using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class UIController : MonoBehaviour
{
    [SerializeField] private Text scoreLabel;

    private void onFlashlightChargeChanged(int charge)
    {
        scoreLabel.text = charge.ToString() + "%";
    }
}
