using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Clic : MonoBehaviour
{
    public bool sobreSiMismo;
    public UnityEvent evento;
    float tiempo;

	private void Start()
	{
        //tiempo = Time.time + 0.2f;
	}

    public void AgendarEspacio()
	{
        tiempo = Time.time + 1;
	}

	void Update()
    {
        if (!sobreSiMismo && Input.GetMouseButtonDown(0) && Time.time > tiempo)
        {
            evento.Invoke();
        }
    }

    private void OnMouseDown()
    {
        if (sobreSiMismo && Time.time > tiempo)
        {
            evento.Invoke();
        }
    }
}
