using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TestNavMeshNPC : MonoBehaviour
{
    public Transform destination;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<NavMeshAgent>().destination = destination.position;
        GetComponent<Animator>().SetBool("Walk", true);
    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<NavMeshAgent>().remainingDistance <= 0.05f)
        {
            GetComponent<Animator>().SetBool("Wait", true);
            GetComponent<Animator>().SetBool("Walk", false);
        }
    }
}
