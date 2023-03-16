using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelEvents : MonoBehaviour
{
    public GameObject _panelSetting;

    public void Bet1K()
    {
        Gameplay.instance.reel1.transform.GetComponent<ReelSymbolShake>().StartShake();
        Gameplay.instance.reel2.transform.GetComponent<ReelSymbolShake>().StartShake();
        Gameplay.instance.reel3.transform.GetComponent<ReelSymbolShake>().StartShake();
        Gameplay.instance.coinUsed = 1000;
        CoinManager.instance.CoinOnChange(-1000);
    }

    public void Bet10K()
    {
        Gameplay.instance.reel1.transform.GetComponent<ReelSymbolShake>().StartShake();
        Gameplay.instance.reel2.transform.GetComponent<ReelSymbolShake>().StartShake();
        Gameplay.instance.reel3.transform.GetComponent<ReelSymbolShake>().StartShake();
        Gameplay.instance.coinUsed = 10000;
        CoinManager.instance.CoinOnChange(-10000);
    }

    public void Bet100K()
    {
        Gameplay.instance.reel1.transform.GetComponent<ReelSymbolShake>().StartShake();
        Gameplay.instance.reel2.transform.GetComponent<ReelSymbolShake>().StartShake();
        Gameplay.instance.reel3.transform.GetComponent<ReelSymbolShake>().StartShake();
        Gameplay.instance.coinUsed = 100000;
        CoinManager.instance.CoinOnChange(-100000);
    }

    public void Bet1M()
    {
        Gameplay.instance.reel1.transform.GetComponent<ReelSymbolShake>().StartShake();
        Gameplay.instance.reel2.transform.GetComponent<ReelSymbolShake>().StartShake();
        Gameplay.instance.reel3.transform.GetComponent<ReelSymbolShake>().StartShake();
        Gameplay.instance.coinUsed = 1000000;
        CoinManager.instance.CoinOnChange(-1000000);
    }

    public void GetCoin()
    {
        CoinManager.instance.CoinOnChange(+10000);
    }

    public void SetProbability()
    {
        _panelSetting.SetActive(true);
    }

    public void CloseSetProbability()
    {

        _panelSetting.SetActive(false);
    }

}
