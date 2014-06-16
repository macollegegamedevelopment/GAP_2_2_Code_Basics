using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ValueVSReference : MonoBehaviour {

	// Use this for initialization
	void Start () {

		// we maken een value type aan
		int speed = 5;
		// en assignen een andere value type dezelfde waarde
		int speed2 = speed;
		
		Debug.Log(speed + " : " + speed2);

		return;

		// wat gebeurd er als we speed2 aanpassen?
		speed2 = 3;
		Debug.Log(speed + " : " + speed2);

		// je zegt 'speed is 'passed by' value'


		// we maken een reference type aan
		List<int> numbers	=	new List<int>();
		// en zetten op index 0 het getal 5
		numbers.Add(5);
		// en assignen een andere variabele met de variabele numbers
		List<int> numbers2	=	numbers;

		Debug.Log(numbers[0] + " : " + numbers2[0]);



		// wat gebeurd er als we numbers 2 aanpassen?
		numbers2[0]	=	3;
		Debug.Log(numbers[0] + " : " + numbers2[0]);

		// dit noem je 'pass by reference'



		// dit werkt ook in een functie

		// we maken een list aan
		List<int> numbers3 = new List<int>();

		// we zetten op index 0 de waarde 7
		numbers3.Add(7);
		Debug.Log(numbers3[0]);



		// vervolgens roepen we de functie aan
		ChangeList(numbers3);
		Debug.Log(numbers3[0]);


		////------ STRUCT

		// struct is een value type waarbinnen een aantal variabelen worden gegroepeerd
		// een voorbeeld hiervan is Vector3
		Vector3 position	=	new Vector3(1,1,1);
		Vector3 position2	=	position;
		position2.x			=	4;

		Debug.Log(position.x + " : " + position2.x);

		// de waarde / value is gekopieerd. Daarna is er totaal geen referentie meer
		// daarom kan je ook niet direct de position aanpassen
		//transform.position.y = 7;
		Vector3 transformPosition	=	transform.position;
		transformPosition.y = 7;
		transform.position	=	transformPosition;

	}
	
	void ChangeList (List<int> list) {
		list[0]	=	4;
	}
}
