using UnityEngine;

public class DoorAnimationOpen : MonoBehaviour
{
    [SerializeField]
    private Door Door;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (!Door.IsOpen)
            {
                Door.Open(other.transform.position);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (Door.IsOpen)
            {
                Door.Close();
            }
        }
    }
}