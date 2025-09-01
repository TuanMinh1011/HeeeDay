using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR;

public class Timer : MonoBehaviour
{
    public string Name { get; private set; }
    public bool IsRunning { get; private set; }

    private DateTime startTime;
    public TimeSpan timeToFinish { get; private set; }
    private DateTime finishTime;
    public UnityEvent TimerFinishEvent;

    public double secondsLeft { get; private set; }

    public int LifeCircle;

    public void Initialize(string processName, DateTime start, TimeSpan time, int lifeCycle)
    {
        Name = processName;

        startTime = start;
        timeToFinish = time;
        finishTime = start.Add(time);
        LifeCircle = lifeCycle;
        //OnUpdateLifeCircle = onUpdateLifeCircle;

        TimerFinishEvent = new UnityEvent();
    }

    public void InitializeForLoadData(string processName, DateTime start, TimeSpan time, int lifeCircle)
    {
        Name = processName;

        startTime = start;
        timeToFinish = time;
        finishTime = start.Add(time);
        LifeCircle = lifeCircle;
        //OnUpdateLifeCircle = onUpdateLifeCircle;

        TimerFinishEvent = new UnityEvent();
    }

    public void StartTimer()
    {
        secondsLeft = timeToFinish.TotalSeconds;
        IsRunning = true;
    }

    private void Update()
    {
        if (IsRunning)
        {
            if (secondsLeft > 0)
            {
                secondsLeft -= Time.deltaTime;
            }
            else
            {
                EndCircle();
            }

            if (LifeCircle <= 0)
            {
                TimerFinishEvent.Invoke();
                secondsLeft = 0;
                IsRunning = false;
            }
        }
    }

    public string DisplayTime()
    {
        string text = "";
        TimeSpan timeLeft = TimeSpan.FromSeconds(secondsLeft);

        if (timeLeft.Days != 0)
        {
            text += timeLeft.Days + "d ";
            text += timeLeft.Hours + "h ";
        }
        else if (timeLeft.Hours != 0)
        {
            text += timeLeft.Hours + "h ";
            text += timeLeft.Minutes + "min";
        }
        else if (timeLeft.Minutes != 0)
        {
            text += timeLeft.Minutes + "min";
            text += timeLeft.Seconds + "sec";
        }
        else if (secondsLeft > 0)
        {
            text += Mathf.FloorToInt((float)secondsLeft) + "sec";
        }
        else
        {
            text = "0sec";
        }

        return text;
    }

    private void EndCircle()
    {
        StartTimer();
        LifeCircle--;

        //OnUpdateLifeCircle?.Invoke(LifeCircle);
        EventManager.Instance.TriggerEvent(new LandUpdateLifeCircleGameEvent(GetComponent<LandController>().Land, LifeCircle));
    }

    public void SkipTimer()
    {
        secondsLeft = 0;
        finishTime = DateTime.Now;
        LifeCircle--;

        //OnUpdateLifeCircle?.Invoke(LifeCircle);
        EventManager.Instance.TriggerEvent(new LandUpdateLifeCircleGameEvent(GetComponent<LandController>().Land, LifeCircle));
    }

    public void SkipAllTimer()
    {
        secondsLeft = 0;
        finishTime = DateTime.Now;
        LifeCircle = 0;

        //OnUpdateLifeCircle?.Invoke(LifeCircle);
        EventManager.Instance.TriggerEvent(new LandUpdateLifeCircleGameEvent(GetComponent<LandController>().Land, LifeCircle));
    }
}
