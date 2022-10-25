using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InimigoRPG : MonoBehaviour
{
    public Image barradeHP;
    public int hpMaximo = 10;
    public int hpAtual = 10;
    public void TomarDano()
    {
        hpAtual -= 1;
        if(hpAtual <= 0)
        {
            Destroy(gameObject);
        }
        barradeHP.fillAmount = 
            (float)hpAtual / (float)hpMaximo;
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
