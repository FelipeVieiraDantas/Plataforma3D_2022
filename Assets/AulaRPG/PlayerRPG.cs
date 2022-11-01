using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerRPG : MonoBehaviour
{
    Animator anim;
    PlayerAttack attack;

    public Transform alvo;
    public LayerMask layerDoChao;

    NavMeshAgent agente;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponentInChildren<Animator>();
        attack = GetComponent<PlayerAttack>();
        agente = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(transform.position,
            alvo.position) > 2)
        {
            anim.SetBool("Andando", true);
        }
        else
        {
            anim.SetBool("Andando", false);
        }


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
