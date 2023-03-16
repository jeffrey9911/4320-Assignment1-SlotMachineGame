using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using TMPro;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    public static CoinManager instance;

    public TMP_Text _coinText;

    private float displayedCoin = 0;

    public int coins { get; private set; }

    private float lerpT = 0;

    private void Awake()
    {
        if(!instance) instance = this;
    }

    private void Start()
    {
        CoinOnChange(10000);
    }

    private void Update()
    {
        if (displayedCoin != coins)
        {
            if(lerpT < 1)
            {
                UpdateCoins();
            }
        }
    }

    public void CoinOnChange(int coinDiff)
    {
        coins += coinDiff;
        lerpT = 0;
    }

    private void UpdateCoins()
    {
        if(Mathf.Approximately(displayedCoin, coins))
        {
            displayedCoin = coins;
        }
        else
        {
            displayedCoin = Mathf.Lerp(displayedCoin, coins, lerpT);
        }
        
        _coinText.text = ((int)displayedCoin).ToString();
        lerpT += Time.deltaTime;
    }
}
