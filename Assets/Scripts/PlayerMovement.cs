using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Vector3 direction;
    [SerializeField] private float playerVelocity = 1;
    private bool canMove = true;

    // Update is called once per frame
    void Update()
    {
        if (canMove)
        {
            // Basic player displacement
            // Get inputs
            direction = new Vector3 (Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            direction = Vector3.ClampMagnitude(direction , 1f); // Normalize for diagonal displacement 

            // Update player position
            if (direction != Vector3.zero)
            {
                transform.position = transform.position + direction*playerVelocity;
            }
        }
        
    }

    /// <summary>
    /// Freeze player movements
    /// </summary>
    public void freezePlayer()
    {
        canMove = false;
    }


    /// <summary>
    /// Unfreeze player movements
    /// </summary>
    public void unfreezePlayer()
    {
        canMove = true;
    }

    public bool getCanMove()
    {
        return canMove;
    }    
}
