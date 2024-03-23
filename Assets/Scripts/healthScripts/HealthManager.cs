using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    [SerializeField]
    private UnityEngine.UI.Image _healthBarForegroundImage;
    public void UpdateHealthBar(healthController healthController)
    {
        float remainingHealthPercentage = healthController.RemainingHealthPercentage;
        _healthBarForegroundImage.fillAmount = remainingHealthPercentage;
    }
}
