using UnityEngine;

public class QuadBackground : MonoBehaviour
{
    [Header("Scrolling Settings")]
    public float scrollSpeed = 0.5f; // Speed at which the texture scrolls
    private Material material;

    private void Start()
    {
        // Get the material of the quad
        material = GetComponent<Renderer>().material;
    }

    private void Update()
    {
        // Calculate the new offset based on time and scroll speed
        float offset = Time.time * scrollSpeed;
        material.mainTextureOffset = new Vector2(offset, 0f);
    }
}
