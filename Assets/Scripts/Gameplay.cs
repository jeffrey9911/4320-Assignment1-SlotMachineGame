using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using System.Net.Http.Headers;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static Gameplay;

public struct Symbol
{
    public Sprite _sprite;
    public float _weight;

    public Symbol(Sprite consSprite, float consWeight)
    {
        _sprite = consSprite;
        _weight = consWeight;
    }
}

public class Gameplay : MonoBehaviour
{
    public static Gameplay instance;

    public Image reel1;
    public Image reel2;
    public Image reel3;

    private int r1 = -1;
    private int r2 = -1;
    private int r3 = -1;

    public int coinUsed = 0;

    public TMP_Text _title;

    public Sprite _question;

    public List<Sprite> symbolSprites = new List<Sprite>();

    public List<Symbol> symbols = new List<Symbol>();

    private void Awake()
    {
        if(!instance)
        {
            instance = this;
        }

        foreach (Sprite sprite in symbolSprites)
        {
            symbols.Add(new Symbol(sprite, 0.1f));

        }
    }

    private void Start()
    {
        
    }

    private void Update()
    {

    }

    public int SpinReel()
    {
        float random = Random.value;
        Debug.Log("Random: " + random);
        float calculateProbability = 0;

        int i = 0;
        for(i = 0; i < symbols.Count; i++)
        {
            calculateProbability += symbols[i]._weight;
            if (random <= calculateProbability) return i;
        }

        return -1;
    }

    public void BetAction()
    {
        r1 = SpinReel();
        r2 = SpinReel();
        r3 = SpinReel();
        CalibrateReels();
        CheckWinLose();
    }

    private void CalibrateReels()
    {
        reel1.sprite = symbols[r1]._sprite;
        reel2.sprite = symbols[r2]._sprite;
        reel3.sprite = symbols[r3]._sprite;
    }

    void CheckWinLose()
    {
        if(r1 == r2 || r1 == r3 || r2 == r3)
        {
            if(r1 == r2 && r1 == r3)
            {
                CoinManager.instance.CoinOnChange(coinUsed * 100);
                _title.text = "x 100 !!! You Win!";
            }
            else
            {
                CoinManager.instance.CoinOnChange(coinUsed * 10);
                _title.text = "x 10 !!! You Win!";
            }
        }
        else
        {
            _title.text = "TRY AGAIN!";
        }
    }
}
