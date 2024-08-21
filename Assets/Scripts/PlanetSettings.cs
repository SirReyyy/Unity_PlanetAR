using UnityEngine;

public class PlanetController : MonoBehaviour
{
    [Header("Planet Settings")]
    [Tooltip("Uniform scale multiplier for the planet.")]
    public float scaleMultiplier = 1.0f;

    [Tooltip("Axial tilt of the planet in degrees.")]
    public float axialTilt = 23.5f;

    [Tooltip("Rotation speed of the planet in degrees per second.")]
    public float rotationSpeed = 15f;

    [Tooltip("Set to true for clockwise rotation, false for counter-clockwise.")]
    public bool rotateClockwise = true;

    public bool isSun, isLarge;

    private void Start()
    {
        // Apply uniform scale to the planet
        if(isSun)
            transform.localScale = Vector3.one * scaleMultiplier * 0.001f;
        else if(isLarge)
            transform.localScale = Vector3.one * scaleMultiplier * 0.005f;
        else
            transform.localScale = Vector3.one * scaleMultiplier * 0.05f;

        // Set the initial rotation to represent the axial tilt around the Z-axis
        transform.rotation = Quaternion.Euler(0f, 0f, axialTilt);
    }

    private void Update()
    {
        // Determine rotation direction
        float direction = rotateClockwise ? -1f : 1f;

        // Rotate the planet around its local up axis (Y-axis) at the specified speed
        transform.Rotate(Vector3.up, rotationSpeed * direction * Time.deltaTime, Space.Self);
    }
}
