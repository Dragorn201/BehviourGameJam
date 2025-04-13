using UnityEngine;
using System.Collections;

public class LightingController : MonoBehaviour
{
    public UnityEngine.Light mainLight;  // Explicitly use Unity's Light

    public float fadeDuration = 1.5f;
    public float darkIntensity = 0.1f;
    public float brightIntensity = 1.0f;

    private void Start()
    {
        if (mainLight != null)
        {
            mainLight.intensity = darkIntensity;
        }
    }

    public void FadeToBright(System.Action onComplete = null)
    {
        StartCoroutine(FadeLight(mainLight.intensity, brightIntensity, onComplete));
    }

    private IEnumerator FadeLight(float from, float to, System.Action onComplete)
    {
        float time = 0f;
        while (time < fadeDuration)
        {
            time += Time.deltaTime;
            float t = time / fadeDuration;

            if (mainLight != null)
                mainLight.intensity = Mathf.Lerp(from, to, t);

            yield return null;
        }

        if (mainLight != null)
            mainLight.intensity = to;

        onComplete?.Invoke();
    }
}