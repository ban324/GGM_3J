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
    [SerializeField] private TextMeshProUGUI Stack1;
    [SerializeField] private TextMeshProUGUI Stack2;
    [SerializeField] private TextMeshProUGUI Stack3;
    [SerializeField] private TextMeshProUGUI Stopturn;

    private void Update()
    {
        lifeText.text = CoinsSys.instance.M_life.ToString();
        enemyLifeText.text = CoinsSys.instance.E_life.ToString();
        coinText.text = CoinsSys.instance.M_coin.ToString();
        enemyCoinText.text = CoinsSys.instance.E_coin.ToString();
        Stack1.text = StackSys.instance.stacks[0].ToString();
        Stack2.text = StackSys.instance.stacks[1].ToString();
        Stack3.text = StackSys.instance.stacks[2].ToString();
    }
}
