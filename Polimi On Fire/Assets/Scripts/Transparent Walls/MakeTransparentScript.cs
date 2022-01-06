using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeTransparentScript : MonoBehaviour
{
    [SerializeField] private List<Iam_InTheWay> currentlyInTheWay;
    [SerializeField] private List<Iam_InTheWay> alreadyTransparent;
    [SerializeField] private Transform player;
    [SerializeField] private Transform _camera;
    private void Awake()
    {
        currentlyInTheWay = new List<Iam_InTheWay>();
        alreadyTransparent = new List<Iam_InTheWay>();
    }
    private void Update()
    {
        GetAllObjectsInTheWay();
        
        MakeObjectsSolid();
        MakeObjectsTransparent();
    }
    
    private void GetAllObjectsInTheWay()
    {
        currentlyInTheWay.Clear();
        
        float cameraPlayerDistance = Vector3.Magnitude(_camera.position - player.position);
        
        Ray ray1_Forward = new Ray(_camera.position, player.position - _camera.position);
        Ray ray1_Backward = new Ray(player.position, _camera.position - player.position);
        
        var hits1_Forward = Physics.RaycastAll(ray1_Forward, cameraPlayerDistance);
        var hits1_Backward = Physics.RaycastAll(ray1_Backward, cameraPlayerDistance);

        foreach (var hit in hits1_Forward)
        {
            if (hit.collider.gameObject.TryGetComponent(out Iam_InTheWay inTheWay))
            {
                if (!currentlyInTheWay.Contains(inTheWay))
                {
                    currentlyInTheWay.Add(inTheWay);
                }
            }
        }
        foreach (var hit in hits1_Backward)
        {
            if (hit.collider.gameObject.TryGetComponent(out Iam_InTheWay inTheWay))
            {
                if (!currentlyInTheWay.Contains(inTheWay))
                {
                    currentlyInTheWay.Add(inTheWay);
                }
            }
        }
    }
    
    private void MakeObjectsTransparent()
    {
        for (int i = 0; i < currentlyInTheWay.Count; i++)
        {
            Iam_InTheWay inTheWay = currentlyInTheWay[i];

            if (!alreadyTransparent.Contains(inTheWay))
            {
                inTheWay.ShowTransparent();
                alreadyTransparent.Add(inTheWay);
            }
        }
    }
    
    private void MakeObjectsSolid()
    {
        for (int i = alreadyTransparent.Count-1; i >= 0; i--)
        {
            Iam_InTheWay wasInTheWay = alreadyTransparent[i];

            if (!currentlyInTheWay.Contains(wasInTheWay))
            {
                wasInTheWay.ShowSolid();
                alreadyTransparent.Remove(wasInTheWay);
            }
        }
    }
}
