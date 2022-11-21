using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StackSys : MonoBehaviour, Instances
{
    public static StackSys instance;
    public Dictionary<int, int> stacks = new Dictionary<int, int>();//�Ǽ��� ����. ���׸�
    [SerializeField]private int reputation;//�Ǹ�
    [SerializeField]private int people;//����
    [SerializeField]private int cult;//����

    public void SetInstance()
    {
        if (instance == null)
        {
            instance = this;

        }
        else Debug.LogError("����");
    }

    private void Awake()
    {
        SetInstance();
        stacks.Add(0, reputation);
        stacks.Add(1, people);
        stacks.Add(3, cult);
    }
}
