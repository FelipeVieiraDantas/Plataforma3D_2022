using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class InimigoControle : MonoBehaviour
{
    public NavMeshAgent agente;
    public Transform destino;

    // Update is called once per frame
    void Update()
    {
        agente.SetDestination(destino.position);
    }
}
