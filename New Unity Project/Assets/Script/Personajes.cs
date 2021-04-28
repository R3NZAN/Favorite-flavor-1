using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

[System.Serializable]
public class Personajes
{
    public string nombre;
    public bool servido;
    public CafeCreation[] nivelDeBebidas;
    public AudioClip voz;
    public AudioClip cancion;
    public int emocion;
    public bool noLeche;
    public string[] dialogo;
}

