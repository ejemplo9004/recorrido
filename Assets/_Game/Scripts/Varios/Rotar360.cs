using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotar360 : MonoBehaviour
{
    public float velocidad;
    public Transform camara;

    public float anguloX = 0;
    public float anguloY = 0;

    public static Rotar360 singleton;
    public bool activo = true;

    public MeshRenderer mr;
    public Texture2D[] fondos; 

    public Material mat;

    void Awake()
    {
        singleton = this;
        CambiarActivo(false, 0);
    }

	private void Start()
	{
        mat = mr.material;
    }

	void Update()
    {
		if (Input.GetMouseButton(0))
		{
            anguloX = Mathf.Clamp((anguloX - (velocidad * Input.GetAxis("Mouse Y") * Time.deltaTime)), -60, 60);
            camara.localEulerAngles = Vector3.left * anguloX;
            anguloY = anguloY + (velocidad * Input.GetAxis("Mouse X") * Time.deltaTime);
            transform.localEulerAngles = Vector3.down * anguloY;
		}
    }

    public void AsignarFondo(int cual)
	{
		if (mat != null)
		{
            mat.SetTexture("_MainTex", fondos[cual]);
		}
	}

    public void CambiarActivo(bool ac, int c)
	{
        AsignarFondo(c);
        activo = ac;
        camara.gameObject.SetActive(ac);
	}
}
