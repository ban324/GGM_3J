using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Effect : MonoBehaviour, Instances
{
    [SerializeField] GameObject _insObj; 
    [SerializeField] public GameObject CardObj;
    public void SetInstance()
    {
        if (instance != null) Debug.Log("Á¿µÊ");
        instance = this;
    }
    
    public static Effect instance;
    public bool EffectEnd;
    public bool ActEnd;
    public bool PassEnd;
    public bool SelectEnd;
    public void AESet(bool end )
    {
        ActEnd = end;
    }
    public void PESet(bool end )
    {
        PassEnd= end;
    }
    public void SESet(bool end )
    {
        SelectEnd= end;
    }
    private void Awake()
    {
        SetInstance();
        ActEnd = false;
        SelectEnd = false;
        PassEnd =false;
    }
    public void GetCoin()
    {
        CoinsSys.instance.M_CoinUp(2);
        StartCoroutine(FloatingTxt("¿±Àü 2 È¹µæ"));
        SelectEnd = true;
        ActEnd = true;
    }
    public void GetHand()
    {
        SelectEnd = true;
        IsCard newCard = Instantiate(CardObj).GetComponent<IsCard>();
        newCard.GetCard();
        HandSys.instance.handCards.Add(newCard);
        ActEnd= true;
        EffectEnd = true;
        StartCoroutine(FloatingTxt("Ä«µå 1Àå È¹µæ"));

    }
    public void ActiveHand()
    {
        SelectEnd = true;
        IsCard newCard = Instantiate(CardObj).GetComponent<IsCard>();
        newCard.GetCard();
        HandSys.instance.handCards.Add(newCard);
        
    }
    public void GetECoin()
    {
        CoinsSys.instance.E_CoinUp(2);
        AESet(true); StartCoroutine(FloatingTxt("¿±Àü 2 È¹µæ"));

    }
    public void GetEHand()
    {
        IsCard newCard = Instantiate(CardObj).GetComponent<IsCard>();
        newCard.GetCard();
        EnemyHandSys.instance.handCards.Add(newCard); StartCoroutine(FloatingTxt("Ä«µå 1Àå È¹µæ"));

    }

    IEnumerator FloatingTxt(string tex)
    {
        Image b = _insObj.GetComponent<Image>();
        TextMeshProUGUI c = b.GetComponentInChildren<TextMeshProUGUI>();
        c.text = tex;
        Color a = new Color(1, 1, 1, 1);
        b.color = a;
        while(a.a > 0)
        {
            a.a-= 0.1f;
            b.color = a;
            c.color = a;
            yield return new WaitForSeconds(0.1f);
        }
        EffectEnd = true;
    }
}
