using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turn : MonoBehaviour, Instances
{
    delegate void TurnEvent(GameObject go, int e);
    TurnEvent a;
    public void SetInstance()
    {
        if (instance != null) Debug.Log("좆됨");
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
            //패시브
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
            //에너미 턴으로 넘김
        }else if(state == State.Enemy_Turn)
        {
            //에너미 시스템에서 행동 끝난거 불 받아서 스탠바이로 변경
            Debug.Log("ENd");
        }
    }
}
