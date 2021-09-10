using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arbol : MonoBehaviour
{
    public string nombreComun;
    public string nombreCientifico;
    [Multiline(5)]
    public string decripcion = "Un árbol típico de la institución que decora los espacios y sirve de habitad para los múltiples ecosistemas que comparten el espacio.";
    public Sprite foto;
    public float ultimoClic;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnMouseDown()
    {
        if (Informacion.MouseEnUI())
        {
            return;
        }
		if (ultimoClic < 1 || Time.time - ultimoClic > 1)
		{
            ultimoClic = Time.time + 0.1f;
		}
		else
		{
			if (Time.time > ultimoClic)
			{
                UIArboles.singleton.MostrarInformacion(nombreComun, nombreCientifico, decripcion, foto);
                ultimoClic = 0;
			}
		}
        
    }
}
