using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turn : MonoBehaviour, Instances
{
    public Sprite[] Sprites;
    [SerializeField] private bool isWait;
    delegate void TurnEvent(GameObject go, int e);
    TurnEvent a;
    public void SetInstance()
    {
        if (instance != null) Debug.Log("Á¿µÊ");
        instance = this;
    }

    
    public static Turn instance;
    public enum State : short
    {
        Standby = 0,
        Select = 1,
        Active = 2,
        Effect = 3,
        End = 4,
        Enemy_Turn = 5
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
            PassiveEff.instance.UsePassive(0);  
            PassiveEff.instance.UsePassive(1);
            Effect.instance.AESet(false);
            Effect.instance.SESet(false);
            Effect.instance.EffectEnd = false;
            Effect.instance.PESet(false);
            Debug.Log("Standby");
            if (!isWait) StartCoroutine(Delay(State.Select));
            
        } else if (state == State.Select)
        {
            SelectManager.instance.PanelActive(true);
            if (Effect.instance.SelectEnd)
            {
                SelectManager.instance.PanelActive(false);
                state = State.Active;
                Debug.Log("Select");
                state = State.Active;
            }
        } else if (state == State.Active)
        {
            if (Effect.instance.ActEnd)
            {
                state = State.Effect;
                Debug.Log("Active");
            }
        }else if(state == State.Effect)
        {
            if (Effect.instance.EffectEnd)
            {
                if (!isWait) StartCoroutine(Delay(State.Enemy_Turn));
                Debug.Log("Effect");
                Effect.instance.EffectEnd = false;

            }
        }
        else if(state == State.Enemy_Turn)
        {
            if (Effect.instance.EffectEnd)
            {
                state = State.End;
                Debug.Log("Enemy");
            }
            else
            {
                CardEffect.instance.disableSteal--;
                EnemyAI.instance.Enemy();
            }
        }
        else if (state == State.End)
        {
            if(!isWait) StartCoroutine(Delay(State.Standby));
        }
    }
    IEnumerator Delay(State Nstate)
    {
        isWait = true;
        yield return new WaitForSeconds(1f);
        state = Nstate;
        isWait = false;
    }
}
