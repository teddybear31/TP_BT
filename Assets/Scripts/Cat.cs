using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Cat : MonoBehaviour
{
    [SerializeField] private NavMeshAgent _agent;
    [SerializeField] private Transform _testPoint;
    // Start is called before the first frame update
    void Start()
    {
        _agent.destination = _testPoint.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
