using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandSys : MonoBehaviour, Instances
{
    public static HandSys instance;
    public List<IsCard> handCards;

    [SerializeField]private Vector2 startP;
    [SerializeField]private Vector2 endP;
    [SerializeField] float Y;
    [SerializeField] float j;

    public void SetInstance()
    {
        instance = this;
        handCards = new List<IsCard>();
    }
    private void Awake()
    {
        SetInstance();
    }
    private void Update()
    {
        if(handCards.Count > 0)
        {
            j = startP.x;
            float a = (endP.x - startP.x) / handCards.Count;
            for (int i = 0; i < handCards.Count; i ++)
            {
                j += a;
                handCards[i].transform.position = new Vector3(j, Y);
            }
        }
    }
}
