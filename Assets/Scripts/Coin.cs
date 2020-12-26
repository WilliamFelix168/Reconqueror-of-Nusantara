using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public delegate void CoinCount(Coin coin);
    public event CoinCount HitCoin;
    void OnTriggerEnter2D(Collider2D co)
    {
        if (co.name == "Character")
            HitCoin?.Invoke(this);
            Destroy(gameObject);
    }

}
