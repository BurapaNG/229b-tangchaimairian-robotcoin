using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class CoinColletion : MonoBehaviour
{
    [SerializeField] private TMP_Text Score;
    private int Coin = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Coin")
        {
            Coin++;
            Debug.Log(Coin);
            Score.text = "Coin: " + Coin;
            Destroy(other.gameObject);
        }
    }
}
