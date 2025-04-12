using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public CanvasGroup MainMenu;
    public CanvasGroup CreditsPanel;
    public CanvasGroup HowPanel;
    public CanvasGroup OptionPanel;

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        // SceneManager.LoadScene("SampleScene");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    private void HideMainMenu()
    {
        MainMenu.alpha = 0;
        MainMenu.blocksRaycasts = false;
    }

    private void ShowPanel(CanvasGroup panel)
    {
        HideMainMenu();
        panel.alpha = 1;
        panel.blocksRaycasts = true;
    }

    public void BackToMenu(CanvasGroup panelToHide)
    {
        panelToHide.alpha = 0;
        panelToHide.blocksRaycasts = false;

        MainMenu.alpha = 1;
        MainMenu.blocksRaycasts = true;
    }

    // 👇 Call these from buttons
    public void SeeCreditsPanel() => ShowPanel(CreditsPanel);
    public void SeeHowPanel() => ShowPanel(HowPanel);
    public void SeeOptionPanel() => ShowPanel(OptionPanel);
}