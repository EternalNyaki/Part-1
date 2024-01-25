using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    public float forwardSpeed = 500f;
    public float steeringSpeed = 200f;

    private float acceleration;
    private float steering;

    private Rigidbody2D rb2d;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        acceleration = Input.GetAxis("Vertical");
        steering = Input.GetAxis("Horizontal");
    }

    private void FixedUpdate()
    {
        rb2d.AddTorque(steering * -steeringSpeed * Time.deltaTime);
        Vector2 force = transform.up * acceleration * forwardSpeed;
        rb2d.AddForce(force * Time.deltaTime);
    }
}
