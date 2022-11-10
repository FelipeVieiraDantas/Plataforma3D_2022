using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Inventario : MonoBehaviour
{
    public GameObject janela;
    public List<GameObject> slots;
    // Start is called before the first frame update
    void Start()
    {
        slots = new List<GameObject>();
        for (int i = 0; i < janela.transform.childCount; i++)
        {
            slots.Add(janela.transform.GetChild(i).gameObject);
            janela.transform.GetChild(i).
                GetChild(0).gameObject.SetActive(false);
            janela.transform.GetChild(i).
                GetChild(1).gameObject.SetActive(false);
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            janela.SetActive(!janela.activeInHierarchy);
        }
    }

    public void AdicionarItem(Item qual)
    {
        foreach(GameObject slot in slots)
        {
            if (slot.transform.GetChild(0).gameObject.
                activeInHierarchy)
            {
                if (slot.transform.GetChild(0).gameObject.
                    GetComponent<Image>().sprite == qual.imagem)
                {
                    slot.transform.GetChild(1).
                        GetComponent<TextMeshProUGUI>().text =
                        (int.Parse(slot.transform.GetChild(1).
                        GetComponent<TextMeshProUGUI>().text) + 1).
                        ToString();
                    return;
                }
            }
        }

        //Chegou até aqui, não tem o item
        foreach(GameObject slot in slots)
        {
            if (!slot.transform.GetChild(0).gameObject.
                activeInHierarchy)
            {
                slot.transform.GetChild(0).gameObject.SetActive(true);
                slot.transform.GetChild(0).GetComponent<Image>().
                    sprite = qual.imagem;
                slot.transform.GetChild(1).gameObject.SetActive(true);
                slot.transform.GetChild(1).
                    GetComponent<TextMeshProUGUI>().text = "1";
                return;
            }
        }
    }
}
