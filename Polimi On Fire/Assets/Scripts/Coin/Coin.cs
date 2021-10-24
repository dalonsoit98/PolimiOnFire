using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public float turnSpeed = 90f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0,0, turnSpeed*Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name != "Player")
        {
            return;
        }
        Destroy(gameObject);
        FindObjectOfType<Score>().ECTsUp();
        FindObjectOfType<AudioManager>().Coins();
    }
}
