using System.Linq.Expressions;
using TurnTheGameOn.ArrowWaypointer;
using UnityEngine;
using UnityEngine.UI;

public class CheckListScript3 : MonoBehaviour
{
    public GameObject toggle1;
    public GameObject toggle2;
    public GameObject toggle3;
    public GameObject toggle4;
    public GameObject toggle5;
    
    public Waypoint waypoint1;
    public Waypoint waypoint2;
    public Waypoint waypoint3;
    public Waypoint waypoint4;
    public Waypoint waypoint5;

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
            case 4:
                toggle4.GetComponent<Toggle>().isOn = true;
                waypoint4.NextWayPoint();
                break;
            case 5:
                toggle5.GetComponent<Toggle>().isOn = true;
                waypoint5.NextWayPoint();
                break;
            default:
                break;
        }
    }

}