using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[System.Serializable]
public class Ingredientes
{
    public string name;
    public int cuanto;
    public Color color;
}

public class Cafe : MonoBehaviour
{
    public float nota;

    [Space(10)]

    public float putuacion;
    public float bebidaTotal;
    public bool evaluar;

    [Space(20)]

    public int suma;
    public Ingredientes[] ingrediente;
    public Image[] imageIngrediente;
    public TextMeshProUGUI textNota;
    Color tazaColorOriginal;

    [Space(20)]

    public CafeCreation bebida;

    void Start()
    {
        tazaColorOriginal = imageIngrediente[0].color;

        bebida.total = 0;
        bebida.Suma();
        bebidaTotal = bebida.total;
    }

    void Update()
    {
        Evaluacion();
    }

    void Evaluacion()
    {
        if(evaluar == true)
        {
            for (var i = 0; i < ingrediente.Length; i++)
            {
                if (bebida.ingrediente[i].cuanto != 0)
                {
                    if (ingrediente[i].cuanto > bebida.ingrediente[i].cuanto)
                    {
                        putuacion += bebida.ingrediente[i].cuanto;

                        if (ingrediente[i].cuanto <= 5)
                        {
                            putuacion += bebida.ingrediente[i].cuanto;
                            putuacion -= ingrediente[i].cuanto;

                            if(putuacion <= 0)
                            {
                                putuacion = 0;
                                putuacion += 1;
                            }
                        }
                    }
                    else
                    {
                        putuacion += ingrediente[i].cuanto;
                    }
                }

                nota = putuacion / bebidaTotal * 10;

                evaluar = false;
            }
        }

        textNota.text = nota.ToString("f0");
    }

    public void Ingrediente(string ing)
    {
        if(suma < 5)
        {
            for (var i = 0; i < ingrediente.Length; i++)
            {
                if (ingrediente[i].name == ing)
                {
                    ingrediente[i].cuanto += 1;
                    imageIngrediente[suma].color = ingrediente[i].color;
                    suma += 1;
                }
            }
        }

    }

    public void Resetear()
    {
        for (var i = 0; i < ingrediente.Length; i++)
        {
            imageIngrediente[0].color = tazaColorOriginal;  
            imageIngrediente[1].color = tazaColorOriginal;
            imageIngrediente[2].color = tazaColorOriginal;
            imageIngrediente[3].color = tazaColorOriginal;
            imageIngrediente[4].color = tazaColorOriginal;

            nota = 0;
            putuacion = 0;
            ingrediente[i].cuanto = 0;
            suma = 0;
        }
    }

    public void Calificar()
    {
        evaluar = true;
    }
}
