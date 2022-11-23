using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI lifeText;
    [SerializeField] private TextMeshProUGUI enemyLifeText;
    [SerializeField] private TextMeshProUGUI coinText;
    [SerializeField] private TextMeshProUGUI enemyCoinText;

    private void Update()
    {
        lifeText.text = CoinsSys.instance.M_life.ToString();
        enemyLifeText.text = CoinsSys.instance.E_life.ToString();
        coinText.text = CoinsSys.instance.M_coin.ToString();
        enemyCoinText.text = CoinsSys.instance.E_coin.ToString();

    }
}
