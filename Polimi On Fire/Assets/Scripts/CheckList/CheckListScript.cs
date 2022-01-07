using System.Linq.Expressions;
using TurnTheGameOn.ArrowWaypointer;
using UnityEngine;
using UnityEngine.UI;

public class CheckListScript : MonoBehaviour
{
    public GameObject toggle1;
    public GameObject toggle2;
    public GameObject toggle3;
    
    public Waypoint waypoint1;
    public Waypoint waypoint2;
    public Waypoint waypoint3;

    public void actionToggle(int id)
    {
        switch (id)
        {
            case 1:
                toggle1.GetComponent<Toggle>().isOn = true;
                waypoint1.NextWayPoint();
                break;
            case 2:
                toggle2.GetComponent<Toggle>().isOn = true;
                waypoint2.NextWayPoint();
                break;
            case 3:
                toggle3.GetComponent<Toggle>().isOn = true;
                waypoint3.NextWayPoint();
                break;
            default:
                break;
        }
    }

}
