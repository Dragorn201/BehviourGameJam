using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;


public class FootstepManager : MonoBehaviour
{
    public AudioResource groundARC;
    public AudioResource stoneARC;
    public AudioResource grassARC;

    private enum Surface { grass, ground, stone};
    private Surface surface;

    private AudioResource currentARC;

    private AudioSource source;

    private void Start()
    {
        source = GetComponent<AudioSource>();
    }

    public void PlayStep ()
    {
        if (currentARC == null)
            return;
        source.resource = currentARC;
        StopAllCoroutines();
        source.Play();
    }

    private void SelectStepList ()
    {
        switch (surface)
        {
            case Surface.grass:
                currentARC = grassARC;
                break;
            case Surface.ground:
                currentARC= groundARC;
                break;
            case Surface.stone:
                currentARC = stoneARC;
                break;
            default:
                currentARC = null;
                break;
        }
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.transform.tag == "Grass")
        {
            surface = Surface.grass;
        }

        if (hit.transform.tag == "Ground")
        {
            surface = Surface.ground;
        }

        if (hit.transform.tag == "Stone")
        {
            surface = Surface.stone;
        }

        SelectStepList();
        
    }

}
