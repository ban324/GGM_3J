using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turn : MonoBehaviour, Instances
{
    public void SetInstance()
    {
        if (instance != null) Debug.Log("����");
        instance = this;
    }

    public static Turn instance;
    public enum State : short
    {
        Standby = 0,
        Select = 1,
        Active = 2,
        Effect = 3,
        Enemy_Turn = 4,
        End = 5
    }
    public State state;
    private void Awake()
    {
        SetInstance();
    }
    private void Update()
    {
        if(state == State.Standby)
        {
            //�� ���� ���� ȿ�������°�
        }else if(state == State.Select)
        {
            //��� ȿ�� ����
        }else if(state == State.Active)
        {
            //�ߵ� ī�� ȿ�� ����
        }else if(state == State.Effect)
        {
            //ī�� ȿ�� ó��
        }else if(state == State.End)
        {
            //���ʹ� ������ �ѱ�
        }else if(state == State.Enemy_Turn)
        {
            //���ʹ� �ý��ۿ��� �ൿ ������ �� �޾Ƽ� ���Ĺ��̷� ����
        }
    }
}
