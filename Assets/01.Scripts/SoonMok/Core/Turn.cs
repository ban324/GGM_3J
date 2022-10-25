using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turn : MonoBehaviour
{
    public enum State : short
    {
        Standby = 0,
        Select = 1,
        Active = 2,
        Effect = 3,
        Enemy_Turn = 4,
        End = 5
    }
    [SerializeField]State state;
    private void Update()
    {
        if(state == State.Standby)
        {
            //턴 시작 전에 효과나오는거
            if (Input.GetKeyDown(KeyCode.K))
            {
                state++;
            }
        }else if(state == State.Select)
        {
            UIManager.Instance.SetPanel(true);
            //사용 효과 선택
            if (Input.GetKeyDown(KeyCode.K) || (GetComponent<Effect>().ActEnd))
            {
                UIManager.Instance.SetPanel(false);
                GetComponent<Effect>().ActEnd = false;
                state++;
            }

        }
        else if(state == State.Active)
        {
            //발동 카드 효과 선택
            if (Input.GetKeyDown(KeyCode.K))
            {
                state++;
            }

        }
        else if(state == State.Effect)
        {
            //카드 효과 처리
            if (Input.GetKeyDown(KeyCode.K))
            {
                state++;
            }

        }
        else if(state == State.End)
        {
            //에너미 턴으로 넘김
            if (Input.GetKeyDown(KeyCode.K))
            {
                state++;
            }

        }
        else if(state == State.Enemy_Turn)
        {
            //에너미 시스템에서 행동 끝난거 불 받아서 스탠바이로 변경
            if (Input.GetKeyDown(KeyCode.K))
            {
                state = State.Standby;
            }

        }
    }
}
