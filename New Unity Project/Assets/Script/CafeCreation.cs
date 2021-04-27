using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Cafe", menuName = "Cafe")]
public class CafeCreation : ScriptableObject
{
    public string cafeName;
    public int total;
    public Ingrediente[] ingrediente;

    //public int cafe, agua, espuma, ron, lecheComun, lecheAlmendra, vainilla, azucar, azucarMoreno, matcha;

    public void Suma()
    {
        for (var i = 0; i < ingrediente.Length; i++)
        {
            total += ingrediente[i].cuanto;
        }
    }

    [System.Serializable]
    public class Ingrediente
    {
        public string name;
        public int cuanto;
    }
}


