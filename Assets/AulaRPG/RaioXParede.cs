using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaioXParede : MonoBehaviour
{
    public LayerMask layersDaParede;
    public Renderer objSumiu;
    public Transform player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit raioBateu;
        Vector3 direcao = player.position 
            - transform.position;
        if (Physics.Raycast(transform.position,
            direcao, out raioBateu, Mathf.Infinity,
            layersDaParede))
        {
            if(raioBateu.transform != player)
            {
                objSumiu = raioBateu.transform.
                    GetComponent<Renderer>();
                Color corOriginal =
                    objSumiu.material.color;
                corOriginal.a = 0; //Alpha
                objSumiu.material.color = corOriginal;
            }
            else
            {
                if(objSumiu != null)
                {
                    Color corTrocada =
                        objSumiu.material.color;
                    corTrocada.a = 1; //Volte a enxergar
                    objSumiu.material.color = corTrocada;
                }
            }
        }
    }
}
