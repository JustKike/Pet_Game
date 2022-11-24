using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    private void Update()
    {
        AllCoinCollected();
    }

    public void AllCoinCollected()
    {

        if (transform.childCount == 0)
        {
            Debug.Log("No quedan Monedas");
        }

    }

}
