using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfoControl : MonoBehaviour
{
    public static InfoControl singleton;
    public Text txtCodigo;
    public Text txtTitulo;
    public Text txtInfo;
    public Image imFoto;

    public Text txtCodigo2;
    public Text txtTitulo2;
    public Text txtInfo2;

    public GameObject objetoCon;
    public GameObject objetoSin;
    public Animator animInfo;


    void Start()
    {
        singleton = this;
    }

    public void Activar(string texto, string codigo, string titulo, Sprite imagen)
    {
        if (imagen == null)
        {
            txtInfo2.text = texto;
            txtCodigo2.text = codigo;
            txtTitulo2.text = titulo;
            objetoSin.SetActive(true);
            objetoCon.SetActive(false);
        }
        else
        {
            txtInfo.text = texto;
            txtCodigo.text = codigo;
            txtTitulo.text = titulo;
            imFoto.sprite = imagen;
            objetoSin.SetActive(false);
            objetoCon.SetActive(true);
        }
        
        animInfo.SetTrigger("activar");
        //Cursor.lockState = CursorLockMode.None;
    }

    public void Desactivar()
    {
        animInfo.SetTrigger("desactivar");
        ControlModos.singleton.OcultarMouse();
    }
}
