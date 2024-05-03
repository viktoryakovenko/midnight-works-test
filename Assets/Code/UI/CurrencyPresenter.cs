using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CurrencyPresenter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _amountLabel;
    [SerializeField] private Image _icon;

    public void SetAmount(int amount)
    {
        if (amount < 0) 
            throw new ArgumentOutOfRangeException();

        _amountLabel.text = amount.ToString();
    }

    public void SetSprite(Sprite sprite) { 
        if (sprite == null)
            throw new NullReferenceException();

        _icon.sprite = sprite;
    }
}
