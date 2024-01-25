using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tire : MonoBehaviour
{
    public float bounceMultiplier;

    private Vector3 force;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Rigidbody2D car = collision.rigidbody;
        force = -collision.GetContact(0).normal.normalized * collision.GetContact(0).normalImpulse * bounceMultiplier;
        car.AddForce(force);
    }

    private void OnDrawGizmos()
    {
        if(force != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(transform.position, transform.position + force);
        }
    }
}
