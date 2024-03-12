using UnityEngine;

public class MeshMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // Adjust this value to control the movement speed

    void Update()
    {
        // Get the input from the keyboard
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Calculate movement direction based on input
        Vector3 moveDirection = new Vector3(horizontalInput, 0, verticalInput).normalized;

        // Move the object based on input and speed
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);
    }
}

