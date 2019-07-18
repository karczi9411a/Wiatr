using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wiatr : MonoBehaviour
{
	public float silawiatru = 5;
	public float zasieg = 100;
	int i;
	public Transform pozycjawiatru;
	public Transform pozcyjarotacjiwiatru;
	private RaycastHit hit;

	void Update()
	{
		//wyjscie aplikacji po escape
		if (Input.GetKeyUp(KeyCode.Escape))
		{
			Application.Quit();
		}

			if (pozycjawiatru != null) //&& pozcyjarotacjiwiatru != null)
		{
			//pozcyjarotacjiwiatru.rotation = transform.rotation;

			//zasieg kolizji
			var hitColliders = Physics.OverlapSphere(pozycjawiatru.transform.position, zasieg);
			for (i = 0; i < hitColliders.Length; i++)
			{
				if (hitColliders[i].GetComponent<Rigidbody>() != null)
				{
					//przechodzenie przez inne obiekty , raydirection
					var rayDirection = hitColliders[i].GetComponent<Rigidbody>().gameObject.transform.position - pozycjawiatru.transform.position;
					if (Physics.Raycast(pozycjawiatru.transform.position, rayDirection, out hit)) 
					{
						if (hit.transform.GetComponent<Rigidbody>())
						{
							//dzialanie sily poprzez hit coliders na inne obiekty
							hitColliders[i].GetComponent<Rigidbody>().AddForce(pozycjawiatru.transform.forward * silawiatru, ForceMode.Acceleration);						
						}
					}
				}
			}
		}

	}
}