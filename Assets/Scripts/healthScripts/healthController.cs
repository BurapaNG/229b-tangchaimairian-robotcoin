﻿using UnityEngine;
using UnityEngine.Events;
public class healthController : MonoBehaviour
{
    [SerializeField]private float _currentHealth;

    [SerializeField]private float _maximumHealth;
    public float RemainingHealthPercentage 
    { 
        get
        { 
            return _currentHealth / _maximumHealth; 
        }
    }
    public UnityEvent OnDie;

    public UnityEvent OnHealthChanged;

    public void TakeDamage(float damageAmount)
    {
        if (_currentHealth == 0)
        {
            return;
        }
        _currentHealth -= damageAmount;

        OnHealthChanged.Invoke(); 

        if (_currentHealth < 0 )
        {
            _currentHealth = 0;
        }
        if (_currentHealth == 0 ) 
        {
            OnDie.Invoke();
        }
    }

    public void AddHealth(float AmountToAdd)
    {
        if ( _currentHealth == _maximumHealth )
        {
            return ;
        }
        _currentHealth += AmountToAdd;

        OnHealthChanged.Invoke();
        if (_currentHealth > _maximumHealth )
        {
            _currentHealth = _maximumHealth;
        }
    }
}