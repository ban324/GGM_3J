using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class GameResult : MonoBehaviour
{
    int i;

    public Image img;

    public Sprite Win;
    public Sprite Draw;
    public Sprite Lose;

    public AudioSource ad;

    public AudioClip BgmWin;
    public AudioClip BgmDraw;
    public AudioClip BgmLose;

    private void Start()
    {
        i = PlayerPrefs.GetInt("WIN", 0);
        switch (i)
        {
            case 1:
                img.sprite = Win;
                ad.clip = BgmWin;
                ad.Play();
                break;

            case 0:
                img.sprite = Draw;
                ad.clip = BgmDraw;
                ad.Play();
                break;

            case 2:
                img.sprite = Lose;
                ad.clip = BgmLose;
                ad.Play();
                break;

        }
    }
}
