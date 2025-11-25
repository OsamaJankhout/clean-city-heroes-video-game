using UnityEngine;

public class CarDrive : MonoBehaviour
{
    public float accel = 20f;
    public float steer = 30f;
    public float maxSpeed = 10f; 
    private Rigidbody rb;

    public Transform[] wheels;
    public float wheelSpin = 360f;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.interpolation = RigidbodyInterpolation.Interpolate;
        rb.collisionDetectionMode = CollisionDetectionMode.Continuous;
    }

    public Vector3 driveDirection = Vector3.forward; 

    private void FixedUpdate()
    {
        float v = Input.GetAxis("Vertical");

        if (rb.linearVelocity.magnitude < maxSpeed)
        {
            rb.AddForce(transform.TransformDirection(driveDirection) * v * accel, ForceMode.Acceleration);
        }

        float h = Input.GetAxis("Horizontal");
        if (v < 0) h = -h;

        float turn = h * steer * Time.fixedDeltaTime;
        rb.MoveRotation(rb.rotation * Quaternion.Euler(0f, turn, 0f));
        SpinWheels(v);
    }

    void SpinWheels(float input)
    {
        if (wheels.Length == 0) return;
        float spin = wheelSpin * input * Time.fixedDeltaTime;

        foreach(Transform wheel in wheels)
        {
            wheel.Rotate(Vector3.right, spin, Space.Self);
        }
    }

}
