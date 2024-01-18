using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Launcher : MonoBehaviour
{
    public GameObject missile;

    private Transform spawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        spawnPoint = GetComponentsInChildren<Transform>()[1];
        Debug.Log(spawnPoint.gameObject.name);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (missile != null)
        {
            Instantiate(missile, spawnPoint.position, spawnPoint.rotation);
        }
    }
}
