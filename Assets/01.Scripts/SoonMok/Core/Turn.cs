using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turn : MonoBehaviour, Instances
{
    delegate void TurnEvent(GameObject go, int e);
    TurnEvent a;
    public void SetInstance()
    {
        if (instance != null) Debug.Log("¡øµ ");
        instance = this;
    }

    public static Turn instance;
    public enum State : short
    {
        Standby = 0,
        Select = 1,
        Active = 2,
        End = 3,
        Enemy_Turn = 4
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
            //∆–Ω√∫Í
            Debug.Log("Standby");
                state = State.Select;
                Effect.instance.PESet(false);
            
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
                state = State.End;
                Effect.instance.ActEnd = false;
            }
        }else if(state == State.End)
        {
            state = State.Enemy_Turn;
            //ø°≥ πÃ ≈œ¿∏∑Œ ≥—±Ë
        }else if(state == State.Enemy_Turn)
        {
            EnemyAI.instance.Enemy();
            Debug.Log("ENd");
            state = State.Standby;
        }
    }
}
