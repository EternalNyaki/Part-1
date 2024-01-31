using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;

    private Rigidbody2D rb2d;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Vector3 distance = transform.right * speed * Time.deltaTime;
        rb2d.MovePosition(transform.position + distance);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        string tag = collision.gameObject.tag;
        if (tag == "Player" || tag == "Bullet")
        {
            Destroy(collision.gameObject);
        }

        Destroy(gameObject);

    }
}
