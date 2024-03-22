using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magnet : MonoBehaviour
{

    public GameObject coinDectectorObj;
    // Start is called before the first frame update
    void Start()
    {
        coinDectectorObj = GameObject.FindGameObjectWithTag("Coin Detector");
        //coinDectectorObj.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            StartCoroutine(ActivateCoin());
            Destroy(gameObject);
        }
    }

    IEnumerator ActivateCoin()
    {
        coinDectectorObj.SetActive(true);
        yield return new WaitForSeconds(10f);
        coinDectectorObj.SetActive(false);
    }
}

