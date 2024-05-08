using System;
using TMPro;
using UnityEngine;

public class CurrencyPresenter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _amountLabel;

    public void SetAmount(int amount)
    {
        if (amount < 0) 
            throw new ArgumentOutOfRangeException();

        _amountLabel.text = amount.ToString();
    }
}
