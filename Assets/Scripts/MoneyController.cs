using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MoneyController : MonoBehaviour
{
    public TextMeshProUGUI moneyText;
    // Start is called before the first frame update
    void Start()
    {
        moneyText.text = MoneyToNewSceneSender.moneyCount;
    }

    
}
