using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class NextLevelTel : MonoBehaviour
{
    public TextMeshProUGUI moneyText;
    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.layer == LayerMask.NameToLayer("Next"))
        {
            MoneyToNewSceneSender.moneyCount = moneyText.text;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
