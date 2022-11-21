using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StackSys : MonoBehaviour, Instances
{
    public static StackSys instance;
    public Dictionary<int, int> stacks = new Dictionary<int, int>();//±Ç¼ø¸ñ Á¦ÀÛ. Á¦³×¸¯
    [SerializeField]private int reputation;//¾Ç¸í
    [SerializeField]private int people;//¹ÎÁß
    [SerializeField]private int cult;//Á¾±³

    public void SetInstance()
    {
        if (instance == null)
        {
            instance = this;

        }
        else Debug.LogError("Á¿µÊ");
    }

    private void Awake()
    {
        SetInstance();
        stacks.Add(0, reputation);
        stacks.Add(1, people);
        stacks.Add(3, cult);
    }
}
