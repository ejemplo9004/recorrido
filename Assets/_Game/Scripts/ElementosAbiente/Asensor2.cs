using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asensor2 : MonoBehaviour
{
    public Transform[] posicionesPisos;
	public SpriteRenderer spFade;

	public GameObject[] interiorActivar;

	float estado = 0;
    public void IrAPiso(int cual)
	{
		StartCoroutine(FadeNegro(cual));
	}
    
    public void Entrar()
	{
		for (int i = 0; i < interiorActivar.Length; i++)
		{
			interiorActivar[i].SetActive(true);
		}
	}

	public void Salir()
	{
		for (int i = 0; i < interiorActivar.Length; i++)
		{
			interiorActivar[i].SetActive(false);
		}
	}

	public IEnumerator FadeNegro(int cual)
	{
		for (int i = 0; i < 30; i++)
		{
			yield return new WaitForSeconds(1f / 30f);
			estado = Mathf.Lerp(estado, 1, 0.3f);
			spFade.color = new Color(0, 0, 0, estado);
		}
		ControlModos.singleton.ReinstanciarPersonaje(posicionesPisos[cual].position);
		for (int i = 0; i < 30; i++)
		{
			yield return new WaitForSeconds(1f / 30f);
			estado = Mathf.Lerp(estado, 0, 0.3f);
			spFade.color = new Color(0, 0, 0, estado);
		}
	}
}
