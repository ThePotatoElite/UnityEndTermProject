using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehavior : MonoBehaviour
{
    
    [SerializeField] 
    Transform Destination;
    [SerializeField]
    private Animator animator;

    NavMeshAgent agent;
    // Start is called before the first frame update

    private void Awake()
    {
        GameStateManager.Instance.OnGameStateChanged += OnGameStateChanged;
    }

    private void OnDestroy()
    {
        GameStateManager.Instance.OnGameStateChanged -= OnGameStateChanged;
    }
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.SetDestination(Destination.position);
    }

    // Update is called once per frame
    void Update()
    {
        if (agent.velocity.magnitude > 0)
        {
            animator.SetBool("isWalking", true);
        }
        else
        {
            animator.SetBool("isWalking", false);
        }
    }
    

    private void OnGameStateChanged(GameState newGameState)
    {
        agent.isStopped = newGameState == GameState.Pause;
    }


}
