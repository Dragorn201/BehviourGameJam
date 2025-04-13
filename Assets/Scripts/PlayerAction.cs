using UnityEngine;
using System.Collections;

public class PlayerAction : MonoBehaviour
{
    private GameObject tilePlayerStandingOn;
    [SerializeField] GameObject ressourceManager;
    private string currentRessource;

    private IEnumerator coroutine;
    [SerializeField] float ressourceHarvestingWaitTime;

    [SerializeField] GameObject lampPlaceholder;

    private void Start()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        
        tilePlayerStandingOn = other.gameObject;
        Debug.Log(tilePlayerStandingOn.GetComponent<Transform>().position);
        lampPlaceholder.GetComponent<LightMagnetToTile>().magnetTo(tilePlayerStandingOn.GetComponent<Transform>().position);
    }

    public void Update()
    {
        // Action when spacebar is pressed
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Check the tile the player is standing on
            currentRessource =  tilePlayerStandingOn.GetComponent<Tile>().GetRessourceType();

            if (currentRessource=="Grass")
            {
                // Add the script to place a light source depending on the one selected
                lampPlaceholder.GetComponent<LightPlaceHolder>().createCurrentlySelectedLamp();
            }
            else
            {
                coroutine = waitToCollectRessource(ressourceHarvestingWaitTime);
                StartCoroutine(coroutine);
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
        Debug.Log("Asked to add wood.");
        GetComponent<PlayerMovement>().unfreezePlayer();
    }
}
