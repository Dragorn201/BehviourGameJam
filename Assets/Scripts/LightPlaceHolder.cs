using UnityEngine;

public class LightPlaceHolder : MonoBehaviour
{
    [SerializeField] GameObject fireCamp;
    [SerializeField] GameObject torch;
    [SerializeField] GameObject candleStick;
    [SerializeField] GameObject greatCandleStick;
    [SerializeField] GameObject lamp;

    public void createCurrentlySelectedLamp()
    {
        //Check that the player has enough ressource to build the selected light
    }
}
