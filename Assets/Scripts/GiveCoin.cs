using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiveCoin : MonoBehaviour
{
    public int coinValue = 1;
    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            ScoreManager.instance.ChangeScore(coinValue);
            ScoreManager.instance.CountCoin(1);
        }
    }
}
