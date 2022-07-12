using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField]
    private Text TimerT;

    [SerializeField]
    private Animator animator;

    [SerializeField]
    [Min(0)]
    private float StartTime;

    [SerializeField]
    private bool ShowNumbersAfterComma;

    [SerializeField]
    private Color TimeFinishedColor;

    private float timeleft;

    public float TimeLeft
    {
        get
        {
            return timeleft;
        }
    }

    void Start()
    {
        timeleft = StartTime;
    }

    private bool wasStarted;

    void Update()
    {
        if(!wasStarted)
        {
            wasStarted = true;
            StartCoroutine(TimerCount());
        }
    }

    private IEnumerator TimerCount()
    {
        if(ShowNumbersAfterComma)
        {
            int iteration = (int)(StartTime * 100);
            for (int i = 0; i < iteration; i++)
            {
                int minutes = (int)((iteration / 100f - i) / 60f);
                string text = "";
                text += $"{minutes}:";
                int seconds = (int)((iteration - i) / 100f - (minutes * 6000));
                if (seconds >= 10)
                    text += seconds.ToString();
                else
                    text += $"0{seconds}";
                int miliseconds = iteration - minutes * 6000 - seconds * 100;
                if (miliseconds >= 10)
                    text += miliseconds.ToString();
                else
                    text += $"0{miliseconds}";
                TimerT.text = text;
                timeleft = (iteration - i) / 100f;
                yield return new WaitForSeconds(0.01f);
            }
        }
        else
        {
            int iteration = (int)(StartTime);
            for (int i = 0; i < iteration; i++)
            {
                int minutes = (int)((iteration - i) / 60f);
                string text = "";
                text += $"{minutes}:";

                int seconds = iteration - i - (minutes * 60);
                if (seconds >= 10)
                    text += seconds.ToString();
                else
                    text += $"0{seconds}";
                TimerT.text = text;
                timeleft = iteration - i;
                yield return new WaitForSeconds(1f);
            }
        }
        timeleft = 0;
        TimerT.text = "0:00";
        TimerT.color = TimeFinishedColor;
        animator.SetInteger("state", 1);
    }
}
