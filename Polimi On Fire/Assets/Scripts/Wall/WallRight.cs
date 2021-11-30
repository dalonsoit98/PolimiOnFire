
using UnityEngine;

public class WallRight : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            FindObjectOfType<PlayerMove>().DFlag = false;
        }
    }
}
