using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StackSys : MonoBehaviour, Instances
{
    public static StackSys instance;
    public Dictionary<int, int> stacks = new Dictionary<int, int>();//권순목 제작. 제네릭
    [SerializeField]private int reputation;//악명
    [SerializeField]private int people;//민중
    [SerializeField]private int cult;//종교

    public void SetInstance()
    {
        if (instance == null)
        {
            instance = this;

        }
    }

    private void Awake()
    {
        SetInstance();
        stacks.Add(0, reputation);//치안
        stacks.Add(1, people);//인구
        stacks.Add(2, cult);//신앙
    }
}
