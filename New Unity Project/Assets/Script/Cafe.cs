using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

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
    public bool sacarNota;

    [Space(20)]

    public Ingredientes[] ingrediente;
    public Image[] imageIngrediente;
    Color tazaColorOriginal;

    [Space(20)]

    public CafeCreation bebida;

    void Start()
    {
        bebida = GM.gm.bebidaActual;

        tazaColorOriginal = imageIngrediente[0].color;

        bebida.total = 0;
        bebida.Suma();
        bebidaTotal = bebida.total;
    }

    void Update()
    {
        Evaluacion();

        GM.gm.colorTazaOriginal = tazaColorOriginal;

        GM.gm.colorIngredientes[0] = imageIngrediente[0].color;
        GM.gm.colorIngredientes[1] = imageIngrediente[1].color;
        GM.gm.colorIngredientes[2] = imageIngrediente[2].color;
        GM.gm.colorIngredientes[3] = imageIngrediente[3].color;
        GM.gm.colorIngredientes[4] = imageIngrediente[4].color;

        nota = GM.gm.nota;
    }

    void Evaluacion()
    {
        if(sacarNota == true)
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

                if (bebida.ingrediente[i].cuanto == 0)
                {
                    if(ingrediente[i].cuanto > 0)
                    {
                        putuacion -= 1f;
                    }
                }

                GM.gm.nota = putuacion / bebidaTotal * 10;

                if (GM.gm.nota < 0f)
                {
                    GM.gm.nota = 0f;
                }
                if (GM.gm.nota > 10f)
                {
                    GM.gm.nota = 10f;
                }

                SceneManager.LoadScene("Escenario 2");

                sacarNota = false;
            }
        }
    }

    public void Ingrediente(string ing)
    {
        if(GM.gm.suma < 5)
        {
            for (var i = 0; i < ingrediente.Length; i++)
            {
                if (ingrediente[i].name == ing)
                {
                    ingrediente[i].cuanto += 1;
                    imageIngrediente[GM.gm.suma].color = ingrediente[i].color;
                    GM.gm.suma += 1;
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
            GM.gm.suma = 0;
        }
    }

    public void Calificar()
    {
        sacarNota = true;
    }
}
