using UnityEngine;

public class MoveLeftRight : MonoBehaviour
{
    public float speed = 3f; // Speed of movement
    public float distance = 5f; // Maximum distance the object moves to the left and right

    private Vector3 startPosition;

    void Start()
    {
        // Store the initial position of the object
        startPosition = transform.position;
    }

    void Update()
    {
        // Move the object left and right using sine wave oscillation
        float newX = startPosition.x + Mathf.Sin(Time.time * speed) * distance;
        transform.position = new Vector3(newX, transform.position.y, transform.position.z);
    }
}
