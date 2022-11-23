using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect : MonoBehaviour, Instances
{
    [SerializeField] private GameObject CardObj;
    public void SetInstance()
    {
        if (instance != null) Debug.Log("Á¿µÊ");
        instance = this;
    }
    
    public static Effect instance;
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
        SelectEnd = true;
        ActEnd = true;
    }
    public void GetHand()
    {
        IsCard newCard = Instantiate(CardObj).GetComponent<IsCard>();
        newCard.GetCard();
        HandSys.instance.handCards.Add(newCard);
        SelectEnd = true;
        ActEnd= true;
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
    }
}
