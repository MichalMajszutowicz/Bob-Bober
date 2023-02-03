using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameEnding : MonoBehaviour
{
    [SerializeField] GameObject endingScreen;

    int howManyCoinsMax;
    int howManyDiamondsMax;
    public TextMeshProUGUI coinCount;
    public TextMeshProUGUI diamondCount;
    private bool istriggered = false;
    void Start() {
        {
            GameObject[] gameObjects1;
            gameObjects1 = GameObject.FindGameObjectsWithTag("Coin");
            GameObject[] gameObjects2;
            gameObjects2 = GameObject.FindGameObjectsWithTag("Diamond");
            howManyCoinsMax = gameObjects1.Length;
            howManyDiamondsMax = gameObjects2.Length;
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Player" && istriggered == false)
        {
            coinCount.text = coinCount.text + "/" + howManyCoinsMax;
            diamondCount.text = diamondCount.text + "/" + howManyDiamondsMax;
            endingScreen.SetActive(true);
            istriggered = true;
            if (Input.GetKeyDown("space")) 
            {      
                Application.Quit();
            }
        }
    }

    
    
}
