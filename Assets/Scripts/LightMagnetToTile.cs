using UnityEngine;

public class LightMagnetToTile : MonoBehaviour
{
    public void magnetTo(Vector3 positionToMagnetTo)
    {
        this.transform.position = positionToMagnetTo;
    }

    /// <summary>
    /// Rotate the light source by sixte degrees
    /// </summary>
    public void sixtyDegreeRotation()
    {
        transform.Rotate(new Vector3(0, 0, 60));
    }


}
