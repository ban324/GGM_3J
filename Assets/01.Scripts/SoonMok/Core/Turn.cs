using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turn : MonoBehaviour, Instances
{
    delegate void TurnEvent(GameObject go, int e);
    TurnEvent a;
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
        if (state == State.Standby)
        {
            //�нú�
            Debug.Log("Standby");
            if (Effect.instance.PassEnd)
            {
                state = State.Select;
                Effect.instance.PESet(false);
            }
        } else if (state == State.Select)
        {
            SelectManager.instance.PanelActive(true);
            if (Effect.instance.SelectEnd)
            {
                SelectManager.instance.PanelActive(false);
                Effect.instance.SESet(false);
                state = State.Active;
            }
        } else if (state == State.Active)
        {
            if (Effect.instance.ActEnd)
            {
                state = State.Effect;
                Effect.instance.ActEnd = false;
            }
        }
        else if (state == State.Effect)
        {
        } else if(state == State.End)
        {
            //���ʹ� ������ �ѱ�
        }else if(state == State.Enemy_Turn)
        {
            //���ʹ� �ý��ۿ��� �ൿ ������ �� �޾Ƽ� ���Ĺ��̷� ����
            Debug.Log("ENd");
        }
    }
}
