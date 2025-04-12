using UnityEngine;

public class Timer : MonoBehaviour
{
    // Day duration
    [SerializeField] private float dayTime = 100 ; //Daytime in seconds
    [SerializeField] private float nightTime = 10; //Nightime in seconds
    private bool isDayTimer = true;


    // Timer
    private bool isRunning = false;
    private bool isStarted = false;
    private float elapsedTime = 0;

    /// <summary>
    /// Reset the timer and start it with night time values
    /// </summary>
    public void StartNightTimer()
    {
        isDayTimer = false;
        elapsedTime = 0;
        isRunning = true;
        isStarted = true;
    }

    /// <summary>
    /// Reset the timer and start it with day time values
    /// </summary>
    public void StartDayTimer()
    {
        isDayTimer = true;
        elapsedTime = 0;
        isRunning = true;
        isStarted = true;
    }

    private void FixedUpdate()
    {
        if (isRunning && isStarted)
        {
            if (isDayTimer)
            {
                elapsedTime += Time.deltaTime;
                if (elapsedTime >= dayTime)
                {
                    isRunning = false;
                    this.GetComponent<DayNightCycle>().changeDay();
                }
            }
            else
            {
                elapsedTime += Time.deltaTime;
                if (elapsedTime >= nightTime)
                {
                    isRunning = false;
                    this.GetComponent<DayNightCycle>().changeDay();
                }
            }
        }
    }

}
