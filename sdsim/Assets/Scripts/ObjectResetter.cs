using UnityEngine;

public class ObjectResetter : MonoBehaviour
{
    // Variables to store the initial snapshot data
    private Vector3 initialPosition;
    private Quaternion initialRotation;
    private Vector3 initialScale;

    void Start()
    {
        // 1. Save the values right when the game begins
        initialPosition = transform.position;
        initialRotation = transform.rotation;
        initialScale = transform.localScale;
    }

    // Call this method whenever you want to reset the object
    public void ResetObject()
    {
        // 2. Restore the original values instantly
        transform.position = initialPosition;
        transform.rotation = initialRotation;
        transform.localScale = initialScale;

        // Optional: If your object uses a Rigidbody physics component, 
        // you should stop its speed/forces when resetting it.
        if (TryGetComponent<Rigidbody>(out Rigidbody rb))
        {
            rb.linearVelocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }
    }
}