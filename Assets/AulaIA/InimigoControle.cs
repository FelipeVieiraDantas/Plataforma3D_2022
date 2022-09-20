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

    // Update is called once per frame
    void Update()
    {
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
