using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public TextMeshProUGUI text;
    public TextMeshProUGUI coinCount;
    public TextMeshProUGUI diamondCount;
    int score;
    int DiamondElements;
    int CoinElements;
    // Start is called before the first frame update

    void Start()
    {
        if(instance==null)
        {
            instance=this;
        }
    }

    public void ChangeScore(int coinValue)
    {
        score+= coinValue;
        text.text =score.ToString();
    }

    public void CountCoin(int cValue)
    {
        CoinElements += cValue;
        coinCount.text=CoinElements.ToString();
    }

    public void CountDiamond(int dValue)
    {
        DiamondElements += dValue;
        diamondCount.text=DiamondElements.ToString();
    }

}
