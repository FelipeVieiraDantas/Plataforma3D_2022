using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public int hp = 5;
    public int forca = 1; //Machado fica mais forte
    public int destreza = 1; //Revolver fica mais forte
    public int inteligencia = 1; //Cetro fica mais forte
    public int estamina = 1; //Tempo entre os ataques

    public int nivelAtual;
    public int XP = 0; //Para mudar de nivel
    public int XPParaOProximo = 100; //Quanto precisa para upar
    public int nivelMaximo = 50;
    //Ao dar level UP, aumenta HP e stamina e tem 1 ponto
    //para distribuir onde quiser

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
