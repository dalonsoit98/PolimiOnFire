
using UnityEngine;

public class WallLeft : MonoBehaviour
{
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            FindObjectOfType<PlayerMove>().AFlag = false;
        }
    }
}
