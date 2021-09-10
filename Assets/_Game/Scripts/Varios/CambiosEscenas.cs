using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CambiosEscenas : MonoBehaviour
{
    public string nombreEscena;
    float tiempo;
    public GameObject cvnLoaging;
    private void Awake()
    {
        tiempo = Time.time + 5;
    }
    public void CambiarEscena()
    {
        if (cvnLoaging != null)
        {
            Instantiate(cvnLoaging);
        }
        VariablesPermanentes.singleton.SetVariable("posicion", JsonUtility.ToJson(transform.position));
        SceneManager.LoadScene(nombreEscena);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (tiempo < Time.time && other.CompareTag("Player"))
        {
            CambiarEscena();
        }
    }
}
