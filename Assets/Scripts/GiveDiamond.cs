using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiveDiamond : MonoBehaviour
{
    public int coinValue = 5;
    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            ScoreManager.instance.ChangeScore(coinValue);
            ScoreManager.instance.CountDiamond(1);
        }
    }
}
