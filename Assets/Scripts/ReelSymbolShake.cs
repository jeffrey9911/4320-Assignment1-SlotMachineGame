using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReelSymbolShake : MonoBehaviour
{
    private bool isShaking = false;
    private float shakingTimer = 0;
    public float shakingTime = 2;

    private Vector2 oriPosition;
    private Vector2 pnoriPosition;

    public GameObject _panel;

    private void Start()
    {
        oriPosition = this.GetComponent<RectTransform>().position;
        if (_panel != null) pnoriPosition = _panel.GetComponent<RectTransform>().position;
    }

    private void Update()
    {
        if(isShaking)
        {
            if(shakingTimer > 0)
            {
                this.GetComponent<Image>().sprite = Gameplay.instance._question;
                this.GetComponent<RectTransform>().position = oriPosition + Random.insideUnitCircle * 5;
                if (_panel != null) _panel.GetComponent<RectTransform>().position = pnoriPosition + Random.insideUnitCircle * 5;
                shakingTimer -= Time.deltaTime;
            }
            else
            {
                isShaking = false;
                if(this.gameObject.name == "IMG_Symbol1") Gameplay.instance.BetAction();
            }

        }
    }


    public void StartShake()
    {
        shakingTimer = shakingTime;
        isShaking = true;
    }

}
