using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerRPG : MonoBehaviour
{
    PlayerAttack attack;

    public Transform alvo;
    public LayerMask layerDoChao;

    NavMeshAgent agente;
    // Start is called before the first frame update
    void Start()
    {
        attack = GetComponent<PlayerAttack>();
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
                out informacoes, Mathf.Infinity,
                layerDoChao))
            {
                Debug.Log("Bati em " + informacoes.collider);
                agente.SetDestination(informacoes.point);
                alvo.position = informacoes.point;
            }
        }

        //Ataque
        if (Input.GetMouseButtonDown(1))
        {
            Ray posicaoNoMundo =
                Camera.main.ScreenPointToRay(
                    Input.mousePosition
                    );

            RaycastHit informacoes;
            if (Physics.Raycast(posicaoNoMundo,
                out informacoes, Mathf.Infinity,
                layerDoChao))
            {
                if (informacoes.transform.GetComponent<InimigoRPG>())
                {
                    Debug.Log("Bati em " + informacoes.collider);
                    agente.SetDestination(informacoes.point);
                    alvo.position = informacoes.point;
                    attack.atacando = informacoes.transform;
                }
            }
        }

    }
}
