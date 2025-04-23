using UnityEngine;

public class SawInteraction : MonoBehaviour
{
    // This should reference your VR controller or player hand
    public Transform handTransform;

    // Optional: assign a button to simulate "click"
    public KeyCode interactionKey = KeyCode.E;

    void Update()
    {
        if (Input.GetKeyDown(interactionKey))
        {
            Ray ray = new Ray(handTransform.position, handTransform.forward);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 5f)) // Adjust range as needed
            {
                GameObject clickedObject = hit.collider.gameObject;

                if (clickedObject.CompareTag("saw") && IsHoldingSaw())
                {
                    clickedObject.SetActive(false);
                }
            }
        }
    }

    // This is a placeholder. Replace this logic with however you're detecting held objects.
    bool IsHoldingSaw()
    {
        // Example: if you have a reference to the held object
        GameObject heldObject = GetHeldObject();
        return heldObject != null && heldObject.CompareTag("saw");
    }

    // Stub for held object detection
    GameObject GetHeldObject()
    {
        // Replace this with your actual VR holding logic
        // For example, if you're using XR Interaction Toolkit:
        // return handTransform.GetComponent<XRDirectInteractor>().selectTarget?.gameObject;
        return null;
    }
}

