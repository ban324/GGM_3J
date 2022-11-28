using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turn : MonoBehaviour, Instances
{
    public Sprite[] Sprites;
    [SerializeField]
    GameObject[] turnImages; 
    [SerializeField] private bool isWait;
    delegate void TurnEvent(GameObject go, int e);
    TurnEvent a;
    public void SetInstance()
    {
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
            state = State.Select;
            
        } else if (state == State.Select)
        {
            SelectManager.instance.PanelActive(true);
            if (Input.GetKeyDown(KeyCode.K)||Effect.instance.SelectEnd)
            {
                SelectManager.instance.PanelActive(false);
                state = State.Active;
                state = State.Active;
            }
        } else if (state == State.Active)
        {
            if (Input.GetKeyDown(KeyCode.K) || Effect.instance.ActEnd)
            {
                state = State.Effect;
            }
        }else if(state == State.Effect)
        {
            if (Effect.instance.EffectEnd)
            {
                if (!isWait) StartCoroutine(Delay(State.Enemy_Turn, 2));
                Effect.instance.EffectEnd = false;

            }
        }
        else if(state == State.Enemy_Turn)
        {
            if (Effect.instance.EffectEnd)
            {
                state = State.End;
                enemyEnd = false;
            }
                CardEffect.instance.disableSteal--;
                EnemyAI.instance.Enemy();
                enemyEnd = true;
            
        }
        else if (state == State.End)
        {
            
            if(!isWait &&!WInLose()) StartCoroutine(Delay(State.Standby, 1));
        }
    }
    public bool enemyEnd;
    public bool WInLose()
    {
        if((CoinsSys.instance.E_coin <0 && CoinsSys.instance.M_coin < 0) || (CoinsSys.instance.E_life < 1 && CoinsSys.instance.M_life < 1))
        {
            if(!isEnd)Effect.instance.floatingTxt("¹«½ÂºÎ!");
            isEnd = true;
            PlayerPrefs.SetInt("WIN", 0);
            return true;
        }
        if(CoinsSys.instance.E_coin <0 ||CoinsSys.instance.E_life < 1)
        {
            if (!isEnd) Effect.instance.floatingTxt("½Â¸®!");
            isEnd = true;
            PlayerPrefs.SetInt("WIN", 1);
            return true;
        }
        if (CoinsSys.instance.M_coin < 0 || CoinsSys.instance.M_life < 1)
        {
            if (!isEnd) Effect.instance.floatingTxt("ÆÐ¹è!");
            isEnd = true;
            PlayerPrefs.SetInt("WIN", 2);
            return true;
        }

        return false;
    }
    public bool isEnd;
    IEnumerator Delay(State Nstate, int times)
    {
        isWait = true;
        yield return new WaitForSeconds(times);
        state = Nstate;
        isWait = false;
    }
}
