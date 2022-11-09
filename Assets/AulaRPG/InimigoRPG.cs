using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InimigoRPG : MonoBehaviour
{
    public GameObject item;
    public Item[] drops;

    public int xp = 50;
    public Image barradeHP;
    public int hpMaximo = 10;
    public int hpAtual = 10;
    public int TomarDano(int quantoDeDano)
    {
        hpAtual -= quantoDeDano;
        if(hpAtual <= 0)
        {
            for (int i = 0; i < drops.Length; i++)
            {
                GameObject novoItem = 
                    Instantiate(item, transform.position,
                transform.rotation);
                novoItem.GetComponent<Coletavel>().item = drops[i];
            }

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
