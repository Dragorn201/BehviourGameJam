using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] string ressourceType;
    [SerializeField] bool isLit = false;
    [SerializeField] int ressourceQuantity;
    [SerializeField] int regenerationCooldown;
    
    
    [Header("Lighted Tile Prefabs")]
    public GameObject lightGrassPrefab;
    public GameObject lightWoodPrefab;
    public GameObject lightCoalPrefab;
    public GameObject lightWaxPrefab;
    public GameObject lightBatteryPrefab;

    public string GetRessourceType()
    {
        return ressourceType;
    }

    public int GetRessourceQuantity()
    {
        return ressourceQuantity;
    }
    public bool GetIsLit()
    {
        return isLit;
    }
    
    public void IlluminateTile()
    {
        isLit = true;
        // Add light to the tile
    }
}
