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

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(bullet != null && Time.frameCount % spawnRate == 0)
        {
            Vector3 targetDirection = player.transform.position - transform.position;
            Instantiate(bullet, transform.position, Quaternion.Euler(targetDirection));
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
        } else if(collision.gameObject == border)
        {
            direction *= -1;
        }
    }
}
