using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerRPG : MonoBehaviour
{
    public Transform alvo;

    NavMeshAgent agente;
    // Start is called before the first frame update
    void Start()
    {
        agente = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray posicaoNoMundo =
                Camera.main.ScreenPointToRay(
                    Input.mousePosition
                    );

            RaycastHit informacoes;
            if (Physics.Raycast(posicaoNoMundo,
                out informacoes, Mathf.Infinity))
            {
                Debug.Log("Bati em " + informacoes.collider);
                agente.SetDestination(informacoes.point);
                alvo.position = informacoes.point;
            }
        }
    }
}
