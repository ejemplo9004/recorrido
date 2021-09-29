using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlModos : MonoBehaviour
{
    public static ControlModos singleton;

    public delegate void Modo();
    public Modo modo0;
    public Modo modo1;
    public GameObject[] elementosM0;
    public GameObject[] elementosM1;
    public GameObject menu;
    public int modoActual;
    public GameObject personaje;
    public GameObject prefabJugador;

    private void Awake()
    {
        singleton = this;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
			if (Rotar360.singleton.activo)
			{
                Rotar360.singleton.CambiarActivo(false, 0);
			}
			else
            {
                menu.SetActive(true);
                //Cursor.lockState = CursorLockMode.None;
            }
        }
    }

    public void OcutarMenu()
    {
        menu.SetActive(false);
        OcultarMouse();
    }

    public void CambiarModo(int cual)
    {
        modoActual = cual;
        switch (cual)
        {
            case 0:
                modo0.Invoke();
                CambiarEstado0(true);
                CambiarEstado1(false);
                break;
            case 1:
                modo1.Invoke();
                CambiarEstado1(true);
                CambiarEstado0(false);
                break;
            default:
                break;
        }
        //MouseOutliner.DesactivarTodos();
        OcutarMenu();
    }

    public void OcultarMouse()
    {
        if (modoActual == 0)
        {
            //Cursor.lockState = CursorLockMode.Locked;
        }
        else
        {
            //Cursor.lockState = CursorLockMode.None;
        }
    }

    public void CambiarEstado0 (bool e)
    {
        foreach (GameObject objeto in elementosM0)
        {
            objeto.SetActive(e);
        }
    }

    public void CambiarEstado1(bool e)
    {
        foreach (GameObject objeto in elementosM1)
        {
            objeto.SetActive(e);
        }
    }


    public void ReinstanciarPersonaje(Vector3 targetPoint)
    {
        Destroy(personaje);
        GameObject go = Instantiate(prefabJugador, targetPoint, Quaternion.identity);
        personaje = go;
        if (ControlModos.singleton != null) ControlModos.singleton.elementosM0[0] = personaje.gameObject;
    }
}
