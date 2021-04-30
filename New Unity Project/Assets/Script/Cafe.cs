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
    public Sprite sprite;
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

    [Space(20)]

    public AudioClip clipTazaNegado;
    public GameObject taza;
    public CafeCreation bebida;


    void Start()
    {
        //GM.gm.personajeActual = 4;

        bebida = GM.gm.bebidaActual;

        imageIngrediente[0].color = GM.gm.colorSinVer;
        imageIngrediente[1].color = GM.gm.colorSinVer;
        imageIngrediente[2].color = GM.gm.colorSinVer;
        imageIngrediente[3].color = GM.gm.colorSinVer;
        imageIngrediente[4].color = GM.gm.colorSinVer;

        bebida.total = 0;
        bebida.Suma();
        bebidaTotal = bebida.total;
    }

    void FixedUpdate()
    {
        Evaluacion();

        GM.gm.spriteIngredientes[0] = imageIngrediente[0].sprite;
        GM.gm.spriteIngredientes[1] = imageIngrediente[1].sprite;
        GM.gm.spriteIngredientes[2] = imageIngrediente[2].sprite;
        GM.gm.spriteIngredientes[3] = imageIngrediente[3].sprite;
        GM.gm.spriteIngredientes[4] = imageIngrediente[4].sprite;

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
                    imageIngrediente[GM.gm.suma].sprite = ingrediente[i].sprite;
                    imageIngrediente[GM.gm.suma].color = GM.gm.colorVer;
                    GM.gm.suma += 1;
                }
            }
        }

    }

    public void IngredienteSonido(AudioClip clip)
    {
        SM.sm.PlayOneShotSE(clip);
    }

    public void AQuienLeServis(int per)
    {
        if (GM.gm.personaje[per].servido == false)
        {
            GM.gm.personajeActual = per;

            if(GM.gm.personaje[per].tazaActive == false)
            {
                taza.SetActive(true);

                SM.sm.PlayBGM(GM.gm.personaje[per].cancion);

                GM.gm.personaje[per].tazaActive = true;
            }
        }
        else
        {
            SM.sm.PlayOneShotSE(clipTazaNegado);
            taza.SetActive(false);
        }
    }

    public void Resetear()
    {
        for (var i = 0; i < ingrediente.Length; i++)
        {
            imageIngrediente[0].color = GM.gm.colorSinVer;  
            imageIngrediente[1].color = GM.gm.colorSinVer;
            imageIngrediente[2].color = GM.gm.colorSinVer;
            imageIngrediente[3].color = GM.gm.colorSinVer;
            imageIngrediente[4].color = GM.gm.colorSinVer;

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

    /*IEnumerator Musica (int per)
    {
        if(cancionActual == true)
        {
            SM.sm.AS[0].volume -= Time.deltaTime;

            if (SM.sm.AS[0].volume <= 0f)
            {
                cancionQueViene = true;
                cancionActual = false;
            }
        }

        yield return new WaitForSecondsRealtime(0.2f);

        if (cancionQueViene == true)
        {
            if(cancion == true)
            {
                SM.sm.PlayBGM(GM.gm.personaje[per].cancion);
                cancion = false;
            }

            SM.sm.AS[0].volume += Time.deltaTime;

            if (SM.sm.AS[0].volume >= 1f)
            {
                cambiarDeCancion = false;
            }
        }
    }*/
}
