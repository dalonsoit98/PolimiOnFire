using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player;
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            player.GetComponent<Animator>().Play("Runtojumpspring");
        }
    }
}
