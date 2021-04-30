using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GM : MonoBehaviour
{
    public static GM gm;

    public float nota;

    public bool evaluar;
    public int nivel;
    public int personajeActual; //0 Programador, 1 Musico, 2 Artista, 3 GD 
    public CafeCreation bebidaActual;
    public Personajes[] personaje;
    public int suma;

    public Sprite[] spriteIngredientes;
    public Color[] colorIngredientes;
    public Color colorSinVer;
    public Color colorVer;

    void Awake()
    {
        if (gm == null)
        {
            DontDestroyOnLoad(gameObject);
            gm = this;
        }
        else if (gm != this)
        {
            Destroy(gameObject);
        }

    }

    // Start is called before the first frame update
    void Start()
    {
        bebidaActual = personaje[personajeActual].nivelDeBebidas[nivel]; //La bebida actual es el personaje actual y el nivel en el que esta
    }

    // Update is called once per frame
    void Update()
    {

    }
}
