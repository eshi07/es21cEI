using UnityEngine;

public class AutoMove : MonoBehaviour
{
    public float moveSpeed = 5f;    // Speed of movement
    public float rotationSpeed = 5f; // Speed of rotation (how fast it turns)
    public float moveRange = 5f;    // Adjustable range for movement (how far the object moves in one direction)

    private bool movingRight = true; // Direction flag to track which way the object is moving
    private Vector3 targetPosition; // Target position the object is moving towards
    private Vector3 startPosition;  // The starting position of the object

    void Start()
    {
        // Save the starting position to calculate the target positions based on moveRange
        startPosition = transform.position;

        // Set the initial target position based on the current position and moveRange
        targetPosition = startPosition + new Vector3(moveRange, 0f, 0f);  // Move 'moveRange' units to the right
    }

    void Update()
    {
        // If the object is moving, execute movement and rotation logic
        MoveObject();
    }

    void MoveObject()
    {
        // Move the object towards the target position
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

        // Smoothly rotate towards the movement direction
        Vector3 targetDirection = targetPosition - transform.position;
        if (targetDirection.magnitude > 0.1f)
        {
            Quaternion targetRotation = Quaternion.LookRotation(targetDirection);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }

        // If the object reaches the target position, change direction
        if (transform.position == targetPosition)
        {
            // Change the direction
            movingRight = !movingRight;

            // Update the target position based on the new direction
            if (movingRight)
                targetPosition = startPosition + new Vector3(moveRange, 0f, 0f);  // Move 'moveRange' units to the right
            else
                targetPosition = startPosition - new Vector3(moveRange, 0f, 0f);  // Move 'moveRange' units to the left
        }
    }
}
