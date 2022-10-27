using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InimigoRPG : MonoBehaviour
{
    public int xp = 50;

    public Image barradeHP;
    public int hpMaximo = 10;
    public int hpAtual = 10;
    public int TomarDano(int quantoDeDano)
    {
        hpAtual -= quantoDeDano;
        if(hpAtual <= 0)
        {
            Destroy(gameObject);
            return xp;
        }
        barradeHP.fillAmount = 
            (float)hpAtual / (float)hpMaximo;
        return 0;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
