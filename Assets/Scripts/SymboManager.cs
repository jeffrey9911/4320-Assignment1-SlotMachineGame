using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SymboManager : MonoBehaviour
{
    public List<SymboText> symboTexts = new List<SymboText>();

    private void Start()
    {
        RefreshWeights();
    }

    public void RefreshWeights()
    {
        for (int i = 0; i < symboTexts.Count; i++)
        {
            symboTexts[i].GetComponent<Image>().sprite = Gameplay.instance.symbols[i]._sprite;
            symboTexts[i]._symbolWeight.text = Gameplay.instance.symbols[i]._weight.ToString();
        }
    }

    public void SaveSetttingOnClick()
    {
        float[] floats = new float[symboTexts.Count];
        float totalSum = 0;

        for(int i = 0; i < floats.Length; i++)
        {
            floats[i] = float.Parse(symboTexts[i]._symbolWeight.text);
            totalSum += floats[i];
        }

        float level = 1 / totalSum;

        for(int i = 0; i < floats.Length;i++)
        {
            Symbol newSymbol = new Symbol(Gameplay.instance.symbols[i]._sprite, floats[i] * level);
            Gameplay.instance.symbols[i] = newSymbol;
        }

        RefreshWeights();
    }


}
