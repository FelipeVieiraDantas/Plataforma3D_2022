using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DanoEmArea : MonoBehaviour
{
    public List<InimigoRPG> inimigosDentro = 
        new List<InimigoRPG>();

    void DanoEmTodoMundo()
    {
        foreach(InimigoRPG inimigo in inimigosDentro)
        {
            inimigo.TomarDano(1);
        }
    }

    void Start()
    {
        InvokeRepeating("DanoEmTodoMundo", 2, 2);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<InimigoRPG>())
        {
            inimigosDentro.Add(
                other.GetComponent<InimigoRPG>());
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<InimigoRPG>())
        {
            inimigosDentro.Remove(
                other.GetComponent<InimigoRPG>());
        }
    }
}
