using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spaceship : MonoBehaviour
{
    public float moveSpeed;
    public float rotateSpeed;

    private float moveInput;
    private float rotateInput;

    Rigidbody2D rb2d;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        moveInput = Input.GetAxis("Vertical");
        rotateInput = Input.GetAxis("Horizontal");
    }

    private void FixedUpdate()
    {
        Vector2 force = transform.up * moveInput * moveSpeed * Time.deltaTime;
        rb2d.AddForce(force);
        rb2d.AddTorque(rotateInput * -rotateSpeed * Time.deltaTime);
    }
}
