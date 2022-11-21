using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turn : MonoBehaviour, Instances
{
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
        if(state == State.Standby)
        {
            //턴 시작 전에 효과나오는거
        }else if(state == State.Select)
        {
            //사용 효과 선택
        }else if(state == State.Active)
        {
            //발동 카드 효과 선택
        }else if(state == State.Effect)
        {
            //카드 효과 처리
        }else if(state == State.End)
        {
            //에너미 턴으로 넘김
        }else if(state == State.Enemy_Turn)
        {
            //에너미 시스템에서 행동 끝난거 불 받아서 스탠바이로 변경
        }
    }
}
