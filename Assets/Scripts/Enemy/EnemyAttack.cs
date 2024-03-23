using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField]
    private float _damageAmount;//????????????

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<PlayerMovement>()) //????????????Amy???????????
        {
            var healthController = collision.gameObject.GetComponent<healthController>();

            healthController.TakeDamage(_damageAmount);
        }
    }
}
