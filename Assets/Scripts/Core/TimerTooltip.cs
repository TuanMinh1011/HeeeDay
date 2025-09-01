using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TimerTooltip : MonoBehaviour
{
    private static TimerTooltip instance;

    private Timer timer;

    [SerializeField] private Camera uiCamera;
    [SerializeField] private TextMeshProUGUI callerNameText;
    [SerializeField] private TextMeshProUGUI timerLeftText;
    [SerializeField] private Button skipButton;
    [SerializeField] private Button skipAllButton;
    [SerializeField] private TextMeshProUGUI liftCycleText;

    private bool countDown;

    private void Awake()
    {
        instance = this;

        transform.parent.gameObject.SetActive(false);
    }

    private void ShowTimer(GameObject caller)
    {
        timer = caller.GetComponent<Timer>();

        if (timer == null)
        {
            return;
        }

        callerNameText.text = timer.Name;
        liftCycleText.text = timer.LifeCircle.ToString();
        skipButton.gameObject.SetActive(true);
        skipAllButton.gameObject.SetActive(true);

        Vector3 position = caller.transform.position - uiCamera.transform.position;
        position = uiCamera.WorldToScreenPoint(uiCamera.transform.TransformPoint(position));
        transform.position = position;

        countDown = true;

        transform.parent.gameObject.SetActive(true);
    }

    private void FixedUpdate()
    {
        if (countDown)
        {
            timerLeftText.text = timer.DisplayTime();
        }
    }

    public void UpdateTooltip()
    {
        callerNameText.text = timer.Name;
        liftCycleText.text = timer.LifeCircle.ToString();

        if (timer.LifeCircle <= 0)
        {
            skipButton.gameObject.SetActive(false);
            skipAllButton.gameObject.SetActive(false);
        }
    }

    public void SkipButton()
    {
        timer.SkipTimer();
        UpdateTooltip();
        //skipButton.gameObject.SetActive(false);
    }

    public void SkipAllButton()
    {
        timer.SkipAllTimer();
        UpdateTooltip();
        //skipAllButton.gameObject.SetActive(false);
    }

    public void HideTimer()
    {
        countDown = false;
        timer = null;
        transform.parent.gameObject.SetActive(false);
    }

    public static void ShowTimer_Static(GameObject caller)
    {
        instance.ShowTimer(caller);
    }

    public static void HideTimer_Static()
    {
        instance.HideTimer();
    }
}
