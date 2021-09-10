using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VariablesPermanentes : MonoBehaviour
{
    public static VariablesPermanentes singleton;
    public List<string> variables = new List<string>();
    public List<string> nombres = new List<string>();
	public bool mjDrone = false;
    public bool mjMillonario1 = false;
    public bool mjMillonario2 = false;
    public bool mjSubmarino = false;
    public bool mjBateria = false;

    [Header("Puntos de información")]
    public AnimacionSecuencia[] animacionesInfo;
    public bool[] activosInfo;

    public void ActualizarMJs(){
		mjDrone = PlayerPrefs.GetInt("mjDrone", 0) == 1;
        print("mjDrone" + PlayerPrefs.GetInt("mjDrone", 0) + " - " + mjDrone);

        mjMillonario1 = PlayerPrefs.GetInt("mjMillonario1", 0) == 1;
        print("mjMillonario1" + PlayerPrefs.GetInt("mjMillonario1", 0) + " - " + mjMillonario1);

        mjMillonario2 = PlayerPrefs.GetInt("mjMillonario2", 0) == 1;
        print("mjMillonario2" + PlayerPrefs.GetInt("mjMillonario2", 0) + " - " + mjMillonario2);

        mjSubmarino = PlayerPrefs.GetInt("mjSubmarino", 0) == 1;
        print("mjSubmarino" + PlayerPrefs.GetInt("mjSubmarino", 0) + " - " + mjDrone);

        mjBateria = PlayerPrefs.GetInt("mjBateria", 0) == 1;
        print("mjBateria" + PlayerPrefs.GetInt("mjBateria", 0) + " - " + mjBateria);

    }

	public bool pedirUno(int cual){
		if(cual == 1){
			return mjDrone;
		}
        else if(cual == 2){
			return mjMillonario1;
        }
        else if (cual == 3)
        {
            return mjSubmarino;
        }
        else if (cual == 4)
        {
            return mjBateria;
        }
        else if(cual == 5){
			return mjMillonario2;
        }
        return false;
	}

    public bool PedirTodos()
    {
        bool infos = false;
        for (int i = 0; i < activosInfo.Length; i++)
        {
            infos = infos || activosInfo[i];
        }
        return (mjBateria && mjDrone && mjMillonario1 && mjMillonario2 && mjSubmarino && !infos);
    }

    private void Awake()
    {
        if (singleton!=null)
        {
            DestroyImmediate(gameObject);
        }
        else
        {
            singleton = this;
            transform.parent = null;
            DontDestroyOnLoad(gameObject);
            PlayerPrefs.SetInt("mjDrone", 0);
            PlayerPrefs.SetInt("mjBateria", 0);
            PlayerPrefs.SetInt("mjMillonario1", 0);
            PlayerPrefs.SetInt("mjMillonario2", 0);
            PlayerPrefs.SetInt("mjSubmarino", 0);
        }
    }

    public void SetVariable(string nombre, string valor)
    {
        int indice = -1;
        for (int i = 0; i < nombres.Count; i++)
        {
            if (nombres[i].Equals(nombre))
            {
                indice = i;
            }
        }
        if (indice == -1)
        {
            nombres.Add(nombre);
            variables.Add(valor);
        }
        else
        {
            variables[indice] = valor;
        }
    }
    public string GetVariable(string nombre)
    {
        int indice = -1;
        for (int i = 0; i < nombres.Count; i++)
        {
            if (nombres[i].Equals(nombre))
            {
                indice = i;
            }
        }
        if (indice == -1)
        {
            return "";
        }
        return variables[indice];
    }

    [ContextMenu("Activar")]
    public void RelledarBooleanos()
    {
        activosInfo = new bool[animacionesInfo.Length];
        for (int i = 0; i < animacionesInfo.Length; i++)
        {
            //animacionesInfo[i].indice = i;
            activosInfo[i] = true;
        }
    }

    public void DesactivarAnimacionInfo(int i)
    {
        activosInfo[i] = false;

    }

}
