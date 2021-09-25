using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using cakeslice;

public class MouseOutliner : MonoBehaviour
{
    public List<Outline> lineasOutlines;
    void Start()
    {
        lineasOutlines = new List<Outline>();
        Outline[] lineas = GetComponentsInChildren<Outline>();
		for (int i = 0; i < lineas.Length; i++)
		{
            lineasOutlines.Add(lineas[i]);
		}
        Outline linea = GetComponent<Outline>();
        if(linea != null) lineasOutlines.Add(linea);
        Desactivar();
    }

	private void OnMouseOver()
	{
        Activar();
	}

    void OnMouseExit()
    {
        Desactivar();
    }
    void Activar()
    {
        for (int i = 0; i < lineasOutlines.Count; i++)
        {
            lineasOutlines[i].enabled = true;
        }
    }

    void Desactivar()
    {
        for (int i = 0; i < lineasOutlines.Count; i++)
        {
            lineasOutlines[i].enabled = false;
        }
    }
}
