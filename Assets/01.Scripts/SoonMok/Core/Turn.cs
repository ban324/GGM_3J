using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turn : MonoBehaviour
{
    public enum State
    {
        Standby,
        Select,
        Active,
        Effect,
        Enemy_Turn,
        End
    }
    State state;
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
