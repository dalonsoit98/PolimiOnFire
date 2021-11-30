using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallCenter : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            FindObjectOfType<PlayerMove>().DFlag = true;
            FindObjectOfType<PlayerMove>().AFlag = true;
        }
    }
}
