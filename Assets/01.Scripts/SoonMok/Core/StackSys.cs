using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StackSys : MonoBehaviour, Instances
{
    public static StackSys instance;
    public List<int> stacks = new List<int>();//�Ǽ��� ����. ���׸�
    [SerializeField]private int reputation;//�Ǹ�
    [SerializeField]private int people;//����
    [SerializeField]private int cult;//����

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
        stacks.Add(reputation);//ġ��
        stacks.Add(people);//�α�
        stacks.Add(cult);//�ž�
    }
    private void Update()
    {
        if (stacks[0] < 0)
        {
            stacks[0] = 0;
        }
    }
}
