using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] string ressourceType;
    [SerializeField] bool isLit;
    [SerializeField] int ressourceQuantity;
    [SerializeField] int regenerationCooldown;

    public string getRessourceType()
    {
        return ressourceType;
    }

    public int getRessourceQuantity()
    {
        return ressourceQuantity;
    }

    public bool getIsLit()
    {
        return isLit;
    }
}
