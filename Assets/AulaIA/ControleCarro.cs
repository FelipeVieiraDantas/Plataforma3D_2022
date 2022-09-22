using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControleCarro : MonoBehaviour
{
    public float velocidade = 10;
    public float velRotacao = 5;
    Rigidbody fisica;

    public bool estaNaAreia;

    // Start is called before the first frame update
    void Start()
    {
        fisica = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(transform.position,
            Vector3.down * 5, Color.red);

        RaycastHit hit;
        if(Physics.Raycast(transform.position,
            Vector3.down, out hit, 5))
        {
            Debug.Log(hit.collider);
            if (hit.collider.CompareTag("Areia"))
            {
                estaNaAreia = true;
            }
            else
            {
                estaNaAreia = false;
            }
        }

        float velocidadeAlterada = velocidade;
        if (estaNaAreia)
        {
            velocidadeAlterada /= 2;
            //velocidadeAlterada = velocidadeAlterada /2
        }


        float movimentoLado = Input.GetAxis("Horizontal");
        float movimentoFrente = Input.GetAxis("Vertical");

        Vector3 novaVelocidade = transform.forward
            * movimentoFrente * velocidadeAlterada;
        novaVelocidade.y = fisica.velocity.y;

        fisica.velocity = novaVelocidade;
        transform.Rotate(0, movimentoLado * velRotacao, 0);
    }
}
