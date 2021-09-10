using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIArboles : MonoBehaviour
{
    [Header("Nombre")]
    public Text txtNombre;
    public Text txtNCientifico;
    public GameObject uiNombres;
    public static UIArboles singleton;
    [Header("Información")]

    public Text txtInfoNombre;
    public Text txtInfoNCientifico;
    public Text txtInfoDescripicion;
    public Image imgInfoFoto;
    public GameObject uiInfoNombres;

    public bool Mostrando => uiNombres.activeSelf;

    private void Awake()
    {
        singleton = this;
    }
    
    public void MostrarNombre(string nombreVulgar, string nombreCientifico)
    {
        txtNombre.text = nombreVulgar;
        txtNCientifico.text = nombreCientifico;
        uiNombres.SetActive(true);
    }

    public void OcultarNombre() => uiNombres.SetActive(false);

    public void MostrarInformacion(string nombreVulgar, string nombreCientifico, string descripcion, Sprite imagen)
    {
        txtInfoNombre.text = nombreVulgar;
        txtInfoNCientifico.text = nombreCientifico;
        txtInfoDescripicion.text = descripcion;
        imgInfoFoto.sprite = imagen;
        uiInfoNombres.SetActive(true);
        //Cursor.lockState = CursorLockMode.None;
    }

    public void OcultarInformacion()
    {
        //Cursor.lockState = CursorLockMode.Locked;
        uiInfoNombres.SetActive(false);
    }

    void Update()
    {
        
    }
}
