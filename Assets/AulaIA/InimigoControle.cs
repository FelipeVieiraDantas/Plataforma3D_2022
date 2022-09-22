using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class InimigoControle : MonoBehaviour
{
    public NavMeshAgent agente;
    public Transform[] destino;
    public int pontoAtual;
    public float distanceAceitavel = 1;

    public float velocidadePadrao = 10;

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position,
            Vector3.down, out hit, 5))
        {
            if (hit.collider.CompareTag("Areia"))
            {
                agente.speed = velocidadePadrao / 2;
            }
            else
            {
                agente.speed = velocidadePadrao;
            }
        }





        // Pega a dist�ncia entre dois pontos
        float distancia =
            Vector3.Distance(transform.position,
            destino[pontoAtual].position);

        //Se a dist�ncia for menor do que a aceit�vel
        //Vamos para o pr�ximo ponto
        if(distancia < distanceAceitavel)
        {
            pontoAtual = pontoAtual + 1;
            //Se eu j� passei por todos os pontos
            //Ent�o vamos voltar para o primeiro!
            if(pontoAtual >= destino.Length)
            {
                pontoAtual = 0;
            }
        }

        agente.SetDestination(destino[pontoAtual].position);
    }
}
