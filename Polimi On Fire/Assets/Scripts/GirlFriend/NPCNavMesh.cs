using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class NPCNavMesh : MonoBehaviour
{
    public Transform Player;
    public float UpdateRate = 0.1f;
    private NavMeshAgent Agent;
    public CharacterController npcController;
    public Animator _animator;

    private void Awake()
    {
        Agent = GetComponent<NavMeshAgent>();
    }

    public void ToggleFollow()
    {
        StartCoroutine(FollowTarget());
    }

    private IEnumerator FollowTarget()
    {
        WaitForSeconds Wait = new WaitForSeconds(UpdateRate);
       
        while(enabled)
        {
            while (FindObjectOfType<PlayerMoveBuilding>().isPaused)
            {
                _animator.enabled = false;
                yield return null;
            }

            _animator.enabled = true;
            Agent.SetDestination(Player.transform.position);
            if (Math.Abs(Vector3.Distance(Player.position, npcController.transform.position)) > 5.92)
            {
                _animator.SetFloat(Const.Speed, 6);
            }
            else
            {
                _animator.SetFloat(Const.Speed,0);
            }

            yield return Wait;
        }
    }
}
