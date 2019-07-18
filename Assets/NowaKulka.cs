using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NowaKulka : MonoBehaviour
{

	public GameObject kulka;
	public float pozycjax;
	public float pozycjay;
	public float pozycjaz;
	public bool zarzadzanie;

	//pobranie pozycji poczatkowych
	void Start()
	{
		pozycjax = kulka.transform.position.x;
		pozycjay = kulka.transform.position.y;
		pozycjaz = kulka.transform.position.z;
	}

	void Update()
	{
		//jesli kulka przekroczy pozycje 
		if (kulka.GetComponent<Transform>().position.x <= -25 || kulka.GetComponent<Transform>().position.x >= 20 || kulka.GetComponent<Transform>().position.z <= -5 || kulka.GetComponent<Transform>().position.z >= 10)
		{
			//wroci do pozycji poczatkowych
			kulka.transform.position = new Vector3(pozycjax, pozycjay, pozycjaz);
		}

		//wylaczenie kinematyki
		if (Input.GetKeyUp(KeyCode.Space))
		{
			kulka.GetComponent<Rigidbody>().isKinematic = false;
		}
	}
}
