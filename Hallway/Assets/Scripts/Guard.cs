using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guard : MonoBehaviour
{
    public Transform target;
    public Transform resetpoint;
    public Transform resetpoint2;
    public Transform guard;
    UnityEngine.AI.NavMeshAgent agent;
    public bool Alertstatus = true;
    public float Monitoring = 1;

    private AudioManager audioManager;

    void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();

        audioManager = AudioManager.instance;
    }

    private static int i = 0;
    private static bool alertPlayed = false;

    void Update()
    {
        if (Alertstatus == true)
        {
            agent.SetDestination(target.position);
            Monitoring = 0;
            if (alertPlayed == false)
            {
                audioManager.PlaySound("alertSound");
                alertPlayed = true;
            }
        }
        if (Alertstatus == false && Monitoring == 1)
        {
            agent.SetDestination(resetpoint.position);
            alertPlayed = false;
            if (resetpoint.position == guard.position)
            {
                Monitoring = 2;
            }
        }
        if (Alertstatus == false && Monitoring == 2)
        {
            agent.SetDestination(resetpoint2.position);
            alertPlayed = false;
            if (resetpoint2.position == guard.position)
            {
                Monitoring = 1;
            }
        }
    }
}
