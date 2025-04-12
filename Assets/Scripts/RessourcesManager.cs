using UnityEngine;

public class RessourcesManager : MonoBehaviour
{
    //Basic ressource manager system - Add new ressources if needed
    private int wood;
    private int wax;
    private int coal;
    private int batterie;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        wood = 0;
        wax = 0;
        coal = 0;
        batterie = 0;

    }

    /// <summary>
    /// Add to a ressource type a given quantity
    /// </summary>
    public void addRessource (string ressourceType, int quantity)
    {
        switch (ressourceType)
        {
            case "Wood":
                wood += quantity;
                break;
            case "Wax":
                wax += quantity;
                break;
            case "Coal":
                coal += quantity;
                break;
            case "Batterie":
                batterie += quantity;
                break;

        }
    }

    /// <summary>
    /// Substract to a ressource type a given quantity without checking if there is enough ressource to substract from. Must be use with function "checkRessource"
    /// </summary>
    public void subRessource(string ressourceType, int quantity)
    {
        switch (ressourceType)
        {
            case "Wood":
                wood -= quantity;
                break;
            case "Wax":
                wax -= quantity;
                break;
            case "Coal":
                coal -= quantity;
                break;
            case "Batterie":
                batterie -= quantity;
                break;

        }
    }
    /// <summary>
    /// Check if there is enough ressource of a certain type to perform an action.
    /// </summary>
    public bool checkRessource(string ressourceType, int quantity)
    {
        switch (ressourceType)
        {
            case "Wood":
                if (quantity<=wood)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            case "Wax":
                if (quantity <= wax)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            case "Coal":
                if (quantity <= coal)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            case "Batterie":
                if (quantity <= batterie)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            default:
                return false;

        }
    }
}

