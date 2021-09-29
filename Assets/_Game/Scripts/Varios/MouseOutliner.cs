using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseOutliner : MonoBehaviour
{

    public List<Outline> lineasOutlines;
    float tiempoActivo;
    public static List<MouseOutliner> todos = new List<MouseOutliner>();
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
        todos.Add(this);
    }

	private void OnMouseOver()
	{
        Activar();
        tiempoActivo = Time.time + 0.1f;
	}

	private void Update()
	{

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

    public static void DesactivarTodos()
	{
		for (int i = 0; i < todos.Count; i++)
		{
			if (todos[i] != null)
			{
                todos[i].Desactivar();
			}
		}
	}
}
