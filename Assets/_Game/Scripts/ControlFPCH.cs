using UnityEngine;
using System.Collections;

public class ControlFPCH : MonoBehaviour
{
	//Desplazamiento en los ejes X y Z
	float movX;
	float movZ;
	//rotación en el eje vertical (el FPC sólo va a rotar sobre este eje)
	float rotY;
	Vector3 mov;
	//las velocidades de movimiento y rotación
	public float vel = 8.0f;
	public float velRot = 180.0f;
	public float fuerzaSalto;
	public float tiempoEsperaSalto;
	public Rigidbody rb;
	public Transform camara;
	// Otras cosas
	[Header("Otros...")]
	public bool bloquearMouse;
	public Consolas consola;
	public Joystick joystick1;
	public Joystick joystick2;


	Vector3 rotCamara;
	float tiempEspera;
	// Use this for initialization
	void Start()
	{
		if (consola == Consolas.windows && bloquearMouse)
		{
			//Cursor.lockState = CursorLockMode.Locked;
		}
		rotCamara = camara.localEulerAngles;
	}

	public void Saltar()
	{
		if (Time.time < tiempEspera)
		{
			return;
		}
		tiempEspera = Time.time + tiempoEsperaSalto;
		rb.velocity = Vector3.up * fuerzaSalto;
	}

	// Update is called once per frame
	void Update()
	{
		if (consola == Consolas.windows)
		{
			rotY = (Input.GetAxisRaw("Horizontal")) * velRot * Time.deltaTime;
			rotCamara = rotCamara + new Vector3(-RotarCamara() * velRot * Time.deltaTime, 0, 0);
		}
		else
		{
			rotY = (joystick2.Horizontal) * velRot * Time.deltaTime;
			rotCamara = rotCamara + new Vector3(-joystick2.Vertical * velRot * Time.deltaTime, 0, 0);
		}
		rotCamara.x = Mathf.Clamp(rotCamara.x, 30, 120);
		camara.localEulerAngles = rotCamara;

		transform.Rotate(0, rotY, 0);
		movX = (Input.GetAxisRaw("Horizontal")+joystick1.Horizontal) * vel * Time.deltaTime*0;
		movZ = (Input.GetAxisRaw("Vertical")+joystick1.Vertical) * vel * Time.deltaTime;
		mov = new Vector3(movX, 0.0f, movZ);
		transform.Translate(mov);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Saltar();
        }
		if (Input.GetKeyDown(KeyCode.P))
		{
			Time.timeScale = 10;
		}
		else if (Input.GetKeyUp(KeyCode.P))
		{
			Time.timeScale = 1;
		}
	}
	float v;
	public float RotarCamara()
	{
		if (Input.GetKey(KeyCode.Q))
		{
			v = Mathf.Lerp(v, 1, 0.2f);
		}else if (Input.GetKey(KeyCode.E))
		{
			v = Mathf.Lerp(v, -1, 0.2f);
		}
		else
		{
			v = Mathf.Lerp(v, 0, 0.2f);
		}
		return v;
	}
}

public enum Consolas
{
	windows, android
}