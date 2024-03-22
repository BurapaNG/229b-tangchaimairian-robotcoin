using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinAttracktor : MonoBehaviour
{
    public float attracktorStrength = 5f;

    public float attracktorRange = 5f;
    
    void FixedUpdate()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, attracktorRange);
        foreach (Collider.CompareTag("coin"))
        {
            
        }
    }
}
