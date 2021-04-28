using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Evaluacion : MonoBehaviour
{
    public GameObject personaje;

    public float velHablar;

    public TextMeshProUGUI textNota;
    public TextMeshProUGUI textNombre;
    public TextMeshProUGUI dialogo;
    public Image[] imageIngrediente;

    public float time;
    bool detener;
    bool n;
    float numero;
    float numero2;

    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        numero = Random.Range(0f, 10f);
        numero2 = 50f;

        n = true;

        anim = personaje.GetComponent<Animator>();

        imageIngrediente[0].color = GM.gm.colorIngredientes[0];
        imageIngrediente[1].color = GM.gm.colorIngredientes[1];
        imageIngrediente[2].color = GM.gm.colorIngredientes[2];
        imageIngrediente[3].color = GM.gm.colorIngredientes[3];
        imageIngrediente[4].color = GM.gm.colorIngredientes[4];

        GM.gm.personaje[GM.gm.personajeActual].emocion = 0;

        StartCoroutine(WriteText("Haber como te quedo el cafe...", velHablar));

        textNombre.text = GM.gm.personaje[GM.gm.personajeActual].nombre;

        StartCoroutine("Tomando", 0.5f);

        detener = false;

        anim.SetLayerWeight(GM.gm.personajeActual, 1.0f);

    }

    private void FixedUpdate()
    {
        anim.SetInteger("Emociones", GM.gm.personaje[GM.gm.personajeActual].emocion);

        time -= Time.deltaTime;

        if (time <= 0 && detener == false)
        {
            n = false;
            GM.gm.evaluar = true;
        }

        if (GM.gm.evaluar == true)
        {
            textNota.text = GM.gm.nota.ToString("f0");

            dialogo.text = "";

            if (GM.gm.nota >= 8)
            {
                StartCoroutine(WriteText(GM.gm.personaje[GM.gm.personajeActual].dialogo[2], velHablar));

                GM.gm.personaje[GM.gm.personajeActual].emocion = 3;
            }

            if (GM.gm.nota <= 7 && GM.gm.nota > 4)
            {
                StartCoroutine(WriteText(GM.gm.personaje[GM.gm.personajeActual].dialogo[1], velHablar));

                GM.gm.personaje[GM.gm.personajeActual].emocion = 2;
            }

            if (GM.gm.nota <= 4)

            {
                StartCoroutine(WriteText(GM.gm.personaje[GM.gm.personajeActual].dialogo[0], velHablar));

                GM.gm.personaje[GM.gm.personajeActual].emocion = 1;
            }

            detener = true;

            GM.gm.evaluar = false;
        }

        if(n == true)
        {
            numero2 -= Time.deltaTime * 9f;
            numero += Time.deltaTime * numero2;

            textNota.text = numero.ToString("f0");

            if (numero > 10)
            {
                numero = 0;
            }
        }
        
    }
    IEnumerator WriteText(string input,float tiempo)
    {
        foreach(char letter in input.ToCharArray())
        {
            dialogo.text += letter;
            SM.sm.Voz(GM.gm.personaje[GM.gm.personajeActual].voz);
            yield return new WaitForSecondsRealtime(tiempo);
        }
    }
    IEnumerator Tomando (float tiempo)
    {   
        yield return new WaitForSecondsRealtime(1.5f);

        imageIngrediente[4].color = GM.gm.colorTazaOriginal;

        yield return new WaitForSecondsRealtime(tiempo);

        imageIngrediente[3].color = GM.gm.colorTazaOriginal;

        yield return new WaitForSecondsRealtime(tiempo);

        imageIngrediente[2].color = GM.gm.colorTazaOriginal;

        yield return new WaitForSecondsRealtime(tiempo);

        imageIngrediente[1].color = GM.gm.colorTazaOriginal;

        yield return new WaitForSecondsRealtime(tiempo);

        imageIngrediente[0].color = GM.gm.colorTazaOriginal;
    }
}
