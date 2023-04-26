using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrencyManager : MonoBehaviour
{
    public static CurrencyManager instance;

    public int coin;

    public int Coin
    {
        get => coin;
        set
        {
            coin = value;
            UIManager.Instance.UpdateCoinUI(coin);
        }
    }

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        coin = 300;
    }

    private void Update()
    {
        UIManager.Instance.UpdateCoinUI(coin);
    }
}
