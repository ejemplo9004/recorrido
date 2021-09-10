using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlAguila : MonoBehaviour
{
	[Header("Otros...")]
	public bool bloquearMouse;
	public Joystick joystick1;
	public Joystick joystick2;
	public Transform hijo;
	public float velRotacion;
	public float velMovimiento;

	Vector3 anguloHijo;
	public Rigidbody miRb;
	// Start is called before the first frame update
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		anguloHijo += (Vector3.up * joystick1.Horizontal * velRotacion + Vector3.left * velRotacion * joystick1.Vertical)*Time.deltaTime;
		hijo.eulerAngles = anguloHijo;
		miRb.velocity= (hijo.forward * joystick2.Vertical + hijo.right * joystick2.Horizontal) * velMovimiento * Time.deltaTime;
    }
}
