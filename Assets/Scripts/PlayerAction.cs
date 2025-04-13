using UnityEngine;
using System.Collections;

public class PlayerAction : MonoBehaviour
{
    private GameObject tilePlayerStandingOn;
    [SerializeField] GameObject ressourceManager;
    private string currentRessource;

    private IEnumerator coroutine;

    [SerializeField] GameObject lampPlaceholder;
    
    private GameObject tile;

    private void Start()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        
        tilePlayerStandingOn = other.gameObject;
        lampPlaceholder.GetComponent<LightMagnetToTile>().magnetTo(tilePlayerStandingOn.GetComponent<Transform>().position);
    }

    public void Update()
    {
        // Action when spacebar is pressed
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Check the tile the player is standing on
            currentRessource =  tilePlayerStandingOn.GetComponent<Tile>().GetRessourceType();

            switch (currentRessource)
            {
                case "Grass":
                    lampPlaceholder.GetComponent<LightPlaceHolder>().createCurrentlySelectedLamp();
                    break;
                case "Wood":
                    coroutine = waitToCollectRessource(2);
                    StartCoroutine(coroutine);
                    break;
                case "Coal":
                    coroutine = waitToCollectRessource(2);
                    StartCoroutine(coroutine);
                    break;
                case "Wax":
                    coroutine = waitToCollectRessource(3);
                    StartCoroutine(coroutine);
                    break;
                case "Battery":
                    coroutine = waitToCollectRessource(4);
                    StartCoroutine(coroutine);
                    break;
                default:
                    Debug.Log("No ressource found");
                    break;
            }

        }

        // Action <hen R is pressed
        if (Input.GetKeyDown(KeyCode.R))
        {
            lampPlaceholder.GetComponent<LightMagnetToTile>().sixtyDegreeRotation();
        }
    }
    /// <summary>
    /// Freeze the player for the waitTime, when it is unfrozen, it harvests the ressource
    /// </summary>
    /// <param name="waitTime"></param>
    /// <returns></returns>
    IEnumerator waitToCollectRessource(float waitTime)
    {
        GetComponent<PlayerMovement>().freezePlayer();
        // suspend execution for waitTime
        yield return new WaitForSeconds(waitTime);
        ressourceManager.GetComponent<RessourcesManager>().addRessource(currentRessource, 1);
        Debug.Log(currentRessource);
        GetComponent<PlayerMovement>().unfreezePlayer();
        tilePlayerStandingOn.GetComponent<Tile>().HarvestRessource();
    }
}
