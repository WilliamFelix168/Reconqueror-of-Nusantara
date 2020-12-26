using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinCount : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI sumCoin = default;
    [SerializeField] private List<Coin> coin = new List<Coin>();

    private long money = 0;

    private void Start()
    {
        for (int i = 0; i < coin.Count; i++)
        {
            coin[i].HitCoin += AddScore;
        }
    }
    private void AddScore(Coin coin)
    {
        money += 100;
        UpdateScore();
    }
    private void UpdateScore()
    {
        sumCoin.text = "Coin : " + money.ToString();
    }
}
    