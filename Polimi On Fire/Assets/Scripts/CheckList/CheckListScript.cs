using System.Linq.Expressions;
using UnityEngine;
using UnityEngine.UI;

public class CheckListScript : MonoBehaviour
{
    public GameObject toggle1;
    public GameObject toggle2;

    public void actionToggle(int id)
    {
        switch (id)
        {
            case 1:
                toggle1.GetComponent<Toggle>().isOn = true;
                break;
            case 2:
                toggle2.GetComponent<Toggle>().isOn = true;
                break;
            default:
                break;
        }
    }

}
