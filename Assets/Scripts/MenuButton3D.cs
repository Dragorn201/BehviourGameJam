using SoundManager;
using UnityEngine;

public class MenuButton3D : MonoBehaviour
{
    public enum ButtonType { Play, Quit, Tutorial, Credits }
    public ButtonType buttonType;
    public MainMenuController menuController;
    public LightingController lightingController;

    void OnMouseDown()
    {
        if (menuController == null) return;

        switch (buttonType)
        {
            case ButtonType.Play:
                if (lightingController != null)
                {
                    lightingController.FadeToBright(() =>
                    {
                        menuController.PlayGame();
                    });
                }
                else
                {
                    menuController.PlayGame();
                }
                break;

            case ButtonType.Quit:
                menuController.QuitGame();
                break;

            case ButtonType.Tutorial:
                menuController.ShowTutorialPanel();
                break;

            case ButtonType.Credits:
                menuController.ShowCreditsPanel();
                break;
        }
    }
}