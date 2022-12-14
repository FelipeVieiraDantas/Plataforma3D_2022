using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentoBayonetta : MonoBehaviour
{
    public float velocidade = 10;
    public float velocidadeRotacao = 70;
    Rigidbody fisica;

    Animator anim;
    bool atacando;

    void Start()
    {
        fisica = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        if (atacando)
        {
            if (!anim.GetCurrentAnimatorStateInfo(0).IsTag("Porrada"))
            {
                atacando = false;
            }
        }

        //Atacar com o bot?o esquerdo do mouse
        if (Input.GetMouseButtonDown(0))
        {
            if (!anim.GetCurrentAnimatorStateInfo(0).IsTag("Porrada"))
            {
                anim.SetTrigger("Ataque");
                atacando = true;
                anim.ResetTrigger("Combo");
            }
            else
            {
                anim.SetTrigger("Combo");
            }
        }


        //Normalmente, o GetAxis tem uma acelera??o.
        //O Raw n?o tem. Vai de 0 para 1 direto.
        float movimentoX = Input.GetAxisRaw("Horizontal");
        float movimentoZ = Input.GetAxisRaw("Vertical");

        Vector3 movimento = new Vector3(movimentoX, 0, movimentoZ);
        //Transformo uma dire??o como se fosse filha da camera
        //para o mundo da unity
        movimento = 
            Camera.main.transform.TransformDirection(movimento);
        movimento.y = 0;

        if (movimento != Vector3.zero)
        {
            Quaternion rotacaoDestino = Quaternion.LookRotation(movimento);
            transform.rotation =
                Quaternion.Lerp(transform.rotation,
                rotacaoDestino, velocidadeRotacao * Time.deltaTime);
        }

        fisica.velocity = movimento * velocidade;

        //Ligar ou desligar anima??o de andando
        if(movimentoX != 0 || movimentoZ != 0)
        {
            anim.SetBool("Andando", true);
        }
        else
        {
            anim.SetBool("Andando", false);
        }
    }
}
