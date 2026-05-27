using UnityEngine;

public class Movimento3d : MonoBehaviour
{
    public float smoothTime = 15;
    public Vector3 velocity = new Vector3(0, 0, 2);
    Vector3 targetPos;

    void Start()
    {
        // Position the camera
        transform.position = new Vector3(0, 3, -10);

        // Create a sphere in front and below the camera.
        Vector3 spherePos = this.transform.position + new Vector3(0, -3, 20);
        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphere.transform.position = spherePos;

        // Set final camera target position to just in front of the sphere
        targetPos = spherePos - new Vector3(0, 0, 2);
    }

    void Update()
    {
        // Smoothly move the camera towards that target position. The velocity 
        // decreases as the camera moves closer to the target position
        transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref velocity, smoothTime);
    }
}
