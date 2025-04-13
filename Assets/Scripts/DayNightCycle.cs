using MusicManagement;
using SoundManager;
using Unity.VisualScripting;
using UnityEngine;

public class DayNightCycle : MonoBehaviour
{

    private bool isItDay = true;
    [SerializeField] GameObject night;
    GameObject blackFading;
    AudioSource musicDay;
    AudioSource musicNight;

    private void Start()
    {
       /* musicDay = MusicDay.GetComponent<AudioSource>();
        musicNight = GetComponent<AudioSource>();*/
        fromNightToDay();
    }
    // Update is called once per frame
    void Update()
    {

    }

    public bool getIsItDay()
    {
        return isItDay;
    }

    /// <summary>
    /// Check the current day-night and change it
    /// </summary>
    public void changeDay()
    {
        if (isItDay)
        {
            fromDayToNight();
        }
        else
        {
            fromNightToDay();
        }

    }

    private void fromDayToNight()
    {
        Debug.Log("NIGHT !");
        // Change day info
        isItDay = false;
        // Screen fades black
        blackFading = Instantiate(night);
        //Reset timer to night time and start it
        GetComponent<Timer>().StartNightTimer();
        // Delete not litted tiles

        // Delete all lights

        // Update ressources on tiles

        // Freeze character movement
        GameObject.FindWithTag("Player").GetComponent<PlayerMovement>().freezePlayer();
        // Sounds
        /*SoundManager.SoundManager.PlaySound(SoundType.BELLNIGHT);

        musicClip = Resources.Load<AudioClip>("Assets/Audio/Music/Middle Earth.wav");
        music.PlayOneShot(musicClip);*/
    }

    private void fromNightToDay()
    {
        Debug.Log("DAY !");
        // Change day info
        isItDay = true;

        // Reset timer to daytime and start it
        GetComponent<Timer>().StartDayTimer();
        // Unfreeze character movement
        GameObject.FindWithTag("Player").GetComponent<PlayerMovement>().unfreezePlayer();
        // Sounds
        SoundManager.SoundManager.PlaySound(SoundType.BELLDAY);

        /*musicClip = Resources.Load<AudioClip>("Assets/Audio/Music/A Beautiful Discovery.wav");
        music.PlayOneShot(musicClip);*/

        Destroy(blackFading);
    }
}
