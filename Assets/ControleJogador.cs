using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControleJogador : MonoBehaviour
{
    Rigidbody fisica;
    public float velocidade = 10;
    public float forcaPulo = 300;

    // Start is called before the first frame update
    void Start()
    {
        //Pegar um componente rigidbody e falar que agora ele se chama fisica
        fisica = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //Pegar um eixo que para a esquerda é -1, para direita 1
        float movimentoX = Input.GetAxis("Horizontal");
        float movimentoY = Input.GetAxis("Vertical");
        //Mostra uma mensagem só pra gente, no Console.
        Debug.Log(movimentoX);

        fisica.velocity = new Vector3(
            movimentoX*velocidade,
            fisica.velocity.y,
            movimentoY * velocidade);

        if (Input.GetKeyDown(KeyCode.Space)) {
            fisica.AddForce(0, forcaPulo, 0);
        }
    }
}
