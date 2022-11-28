using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StackSys : MonoBehaviour, Instances
{
    public static StackSys instance;
    public List<int> stacks = new List<int>();//권순목 제작. 제네릭
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
        stacks.Add(reputation);//치안
        stacks.Add(people);//인구
        stacks.Add(cult);//신앙
    }
    private void Update()
    {
        if (stacks[0] < 0)
        {
            stacks[0] = 0;
        }
    }
}
