using UnityEngine;

public class Light : MonoBehaviour
{
    [SerializeField] int woodRessourceCost;
    [SerializeField] int waxRessourceCost;
    [SerializeField] int batterieRessourceCost;
    [SerializeField] int coalRessourceCost;
    [SerializeField] float buildingTime;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int giveRessourceCost(string ressourceName)
    {
        switch (ressourceName)
        {
            case "Wood":
                return woodRessourceCost;
            case "Wax":
                return waxRessourceCost;
            case "Batterie":
                return batterieRessourceCost;
            case "Coal":
                return coalRessourceCost;
            default:
                return 100;
        }
    }

    public float getBuildingTime()
    {
        return buildingTime;
    }
}
