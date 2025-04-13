using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class MainMenuController : MonoBehaviour
{
    public CanvasGroup MainMenu;
    public CanvasGroup CreditsPanel;
    public CanvasGroup HowPanel;
    public CanvasGroup OptionPanel;
    public Image ScreenOverlay; // A full-screen dark UI Image
    public float fadeDuration = 1.0f;

    private void Start()
    {
        // Start screen slightly dark
        if (ScreenOverlay != null)
        {
            Color c = ScreenOverlay.color;
            c.a = 0.6f;
            ScreenOverlay.color = c;
        }

        // Hide all secondary panels
        HidePanel(CreditsPanel, instant: true);
        HidePanel(HowPanel, instant: true);
        HidePanel(OptionPanel, instant: true);

        // Show main menu
        ShowPanel(MainMenu, instant: true);
    }

    public void PlayGame()
    {
        // Fade screen from dark to light, then load game
        StartCoroutine(FadeScreenOverlay(0f, () =>
        {
            SceneManager.LoadScene("SoundTests");
        }));
    }

    public void QuitGame()
    {
        // Fade screen to black, then quit
        StartCoroutine(FadeScreenOverlay(1f, () =>
        {
            Application.Quit();
        }));
    }

    public void SeePanel(CanvasGroup targetPanel)
    {
        StartCoroutine(SwitchPanels(MainMenu, targetPanel));
    }

    public void BackToMenu(CanvasGroup fromPanel)
    {
        StartCoroutine(SwitchPanels(fromPanel, MainMenu));
    }

    // Need for the new 3D menu, can maybe clean this up later
    public void ShowCreditsPanel()
    {
        SeePanel(CreditsPanel);
    }

    // needed for the new 3D menu, can maybe clean this up later
    public void ShowTutorialPanel()
    {
        SeePanel(HowPanel);
    }

    private IEnumerator SwitchPanels(CanvasGroup from, CanvasGroup to)
    {
        yield return StartCoroutine(FadeCanvasGroup(from, 0f));
        from.blocksRaycasts = false;

        to.blocksRaycasts = true;
        yield return StartCoroutine(FadeCanvasGroup(to, 1f));
    }

    private void HidePanel(CanvasGroup panel, bool instant = false)
    {
        panel.alpha = 0f;
        panel.blocksRaycasts = false;
        if (!instant) StartCoroutine(FadeCanvasGroup(panel, 0f));
    }

    private void ShowPanel(CanvasGroup panel, bool instant = false)
    {
        panel.alpha = 1f;
        panel.blocksRaycasts = true;
        if (!instant) StartCoroutine(FadeCanvasGroup(panel, 1f));
    }

    private IEnumerator FadeCanvasGroup(CanvasGroup group, float targetAlpha)
    {
        float startAlpha = group.alpha;
        float time = 0f;

        while (time < fadeDuration)
        {
            time += Time.deltaTime;
            float t = Mathf.Clamp01(time / fadeDuration);
            group.alpha = Mathf.Lerp(startAlpha, targetAlpha, t);
            yield return null;
        }

        group.alpha = targetAlpha;
    }

    private IEnumerator FadeScreenOverlay(float targetAlpha, System.Action onComplete = null)
    {
        float startAlpha = ScreenOverlay.color.a;
        float time = 0f;
        Color c = ScreenOverlay.color;

        while (time < fadeDuration)
        {
            time += Time.deltaTime;
            float t = Mathf.Clamp01(time / fadeDuration);
            c.a = Mathf.Lerp(startAlpha, targetAlpha, t);
            ScreenOverlay.color = c;
            yield return null;
        }

        c.a = targetAlpha;
        ScreenOverlay.color = c;
        onComplete?.Invoke();
    }
}