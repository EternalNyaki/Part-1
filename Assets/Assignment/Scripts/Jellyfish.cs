using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jellyfish : MonoBehaviour
{
    public float speed;
    public int spawnRate;

    public GameObject bullet;
    public GameObject player;
    public GameObject border;

    private int direction = 1;

    private Rigidbody2D rb2d;

    private Vector3 test;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(bullet != null && player != null && Time.frameCount % spawnRate == 0)
        {
            //Ah yes, I love spending hours sorting through Unity's documentation trying to figure out
            //which goddamn method does the thing I want
            Vector3 targetDirection = player.transform.position - transform.position;
            test = targetDirection.normalized;
            float targetAngle = Vector3.SignedAngle(Vector3.right, targetDirection, Vector3.forward);
            Instantiate(bullet, transform.position, Quaternion.Euler(new Vector3(0, 0, targetAngle)));
        }
    }

    private void FixedUpdate()
    {
        rb2d.MovePosition(transform.position + new Vector3(0, speed * direction * Time.deltaTime, 0));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject == player)
        {
            Destroy(player);
        } 
        else if(collision.gameObject == border)
        {
            direction *= -1;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawLine(transform.position, transform.position + test);
    }
}
