using UnityEngine;
using System.Collections;

public class LightPlaceHolder : MonoBehaviour
{
    [SerializeField] GameObject fireCamp;
    [SerializeField] GameObject torch;
    [SerializeField] GameObject candleStick;
    [SerializeField] GameObject greatCandleStick;
    [SerializeField] GameObject lamp;

    private GameObject currentlySelectedLamp;

    private IEnumerator coroutine;

    public void Awake()
    {
        currentlySelectedLamp = torch;
    }

    public void createCurrentlySelectedLamp()
    {
        //Check that the player has enough ressource to build the selected light
        //check wood
        bool isWoodEnough = GameObject.Find("RessourcesManager").GetComponent<RessourcesManager>().checkRessource("Wood", currentlySelectedLamp.GetComponent<Light>().giveRessourceCost("Wood"));
        //check wax
        bool isWaxEnough = GameObject.Find("RessourcesManager").GetComponent<RessourcesManager>().checkRessource("Wax", currentlySelectedLamp.GetComponent<Light>().giveRessourceCost("Wax"));
        //check batterie
        bool isBatterieEnough = GameObject.Find("RessourcesManager").GetComponent<RessourcesManager>().checkRessource("Batterie", currentlySelectedLamp.GetComponent<Light>().giveRessourceCost("Batterie"));
        //check coal
        bool isCoalEnough = GameObject.Find("RessourcesManager").GetComponent<RessourcesManager>().checkRessource("Coal", currentlySelectedLamp.GetComponent<Light>().giveRessourceCost("Coal"));

        Debug.Log("Wood");
        Debug.Log(isWoodEnough);
        Debug.Log("Coal");
        Debug.Log(isCoalEnough);
        Debug.Log("Wax");
        Debug.Log(isWaxEnough);
        Debug.Log("Batterie");
        Debug.Log(isBatterieEnough);
        //If there is enough ressources, build it
        if (isWoodEnough && isWaxEnough && isBatterieEnough && isCoalEnough)
        {
            //Wait to build
            coroutine = waitToBuildLight(currentlySelectedLamp.GetComponent<Light>().getBuildingTime());
            StartCoroutine(coroutine);

            Debug.Log("Lamp "+currentlySelectedLamp.name);
            switch (currentlySelectedLamp.name)
            {
                case "fireCamp":
                    SoundManager.SoundManager.PlaySound(SoundManager.SoundType.CAMPFIRECRAFT);
                    break;
                case "P_Torch_wCollider":
                    SoundManager.SoundManager.PlaySound(SoundManager.SoundType.TORCHCRAFT);
                    break;
                case "candleStick":
                    SoundManager.SoundManager.PlaySound(SoundManager.SoundType.CANDLECRAFT);
                    break;
                case "greatCandleStick":
                    SoundManager.SoundManager.PlaySound(SoundManager.SoundType.CHANDELIERCRAFT);
                    break;
                case "lamp":
                    SoundManager.SoundManager.PlaySound(SoundManager.SoundType.LAMPCRAFT);
                    break;
            }

            //And consume the ressource
            //check wood
            GameObject.Find("RessourcesManager").GetComponent<RessourcesManager>().subRessource("Wood", currentlySelectedLamp.GetComponent<Light>().giveRessourceCost("Wood"));
            //check wax
            GameObject.Find("RessourcesManager").GetComponent<RessourcesManager>().subRessource("Wax", currentlySelectedLamp.GetComponent<Light>().giveRessourceCost("Wax"));
            //check batterie
            GameObject.Find("RessourcesManager").GetComponent<RessourcesManager>().subRessource("Batterie", currentlySelectedLamp.GetComponent<Light>().giveRessourceCost("Batterie"));
            //check coal
            GameObject.Find("RessourcesManager").GetComponent<RessourcesManager>().subRessource("Coal", currentlySelectedLamp.GetComponent<Light>().giveRessourceCost("Coal"));
        }
        else
        {
            Debug.Log("Can't pay to build light.");
        }
    }

    IEnumerator waitToBuildLight(float waitTime)
    {
        GameObject.Find("Player").GetComponent<PlayerMovement>().freezePlayer();
        // suspend execution for waitTime
        yield return new WaitForSeconds(waitTime);
        Instantiate(currentlySelectedLamp, transform.position, transform.rotation);
        GameObject.Find("Player").GetComponent<PlayerMovement>().unfreezePlayer();
    }

}
