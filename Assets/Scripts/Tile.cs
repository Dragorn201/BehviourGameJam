using System.Dynamic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] string ressourceType;
    [SerializeField] GameObject lightedTilePrefab;
    [SerializeField] bool isLit = false;
    [SerializeField] int ressourceQuantity;
    [SerializeField] int regenerationCooldown;

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

        if (!isLit)
        {
            isLit = true;
            // Add light to the tile
            Instantiate(lightedTilePrefab, transform.position, transform.rotation);
            Debug.Log("Replaced the tile with a lighted one");
            Destroy(gameObject);
            Debug.Log("Destroyed");
        }
        
    }
}
