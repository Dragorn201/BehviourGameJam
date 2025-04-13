using UnityEngine;

public class LightCollider : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        var tileToReplace = other.gameObject;
        tileToReplace.GetComponent<Tile>().IlluminateTile();
    }
}
