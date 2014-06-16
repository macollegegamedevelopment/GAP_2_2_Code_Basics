using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {

	[SerializeField]
	private GameObject prefab;

	List<GameObject> towers			=	new List<GameObject>();

	// Use this for initialization
	void Start () {


		// we maken een list aan met alle start posities
		List<Vector3> startPositions	=	new List<Vector3>();

		startPositions.Add(	new Vector3(-5,0,0)	);
		startPositions.Add(	new Vector3(-3,0,0)	);
		startPositions.Add(	new Vector3(-1,0,0)	);
		startPositions.Add(	new Vector3(1,0,0)	);
		startPositions.Add(	new Vector3(3,0,0)	);
		startPositions.Add(	new Vector3(5,0,0)	);

		/*// dit is hetzelfde. Zo maken we een lijst aan met direct standaard waardes:
		List<Vector3> startPositions = new List<Vector3>{	new Vector3(-5,0,0),
		new Vector3(-3,0,0),
		new Vector3(-1,0,0),
		new Vector3(1,0,0),
		new Vector3(3,0,0),
		new Vector3(5,0,0)};*/
		                   		
		Quaternion rot = Quaternion.identity; // Quaternion.identity essentially means "no rotation"

		// dit is een reference variable. Een variabele die verwijst naar een ander stuk geheugen
		GameObject newTower;

		// we 'kopieren' de value type (passed by value)
		int l = startPositions.Count;
		for(var i = 0; i < l; i++)
		{
			// creeer de nieuwe toren
			newTower		=	Instantiate(prefab, startPositions[i], rot) as GameObject;
			// voeg hem toe aan de list zodat we er later doorheen kunnen loopen
			towers.Add(newTower);

			// we geven de nieuwe toren een unieke naam
			newTower.name	=	"tower" + i;
			// en hij krijgt een script om te kunnen roteren en schieten
			newTower.AddComponent<TowerRotation>();
			newTower.AddComponent<TowerShooting>();
		}

	}

	void Update () {
		if (Input.GetKeyDown (KeyCode.Space))
		{
			Shoot();
		}
	}

	void Shoot(){

		// we kiezen random 1 van de torens
		int index	=	Random.Range( 0, towers.Count );

		// vervolgens laten we hem schieten
		towers[index].GetComponent<TowerShooting>().Shoot();

		// plus we passen de yPositie aan
		Vector3 pos	=	towers[index].transform.position;
		pos.y += 1;
		towers[index].transform.position	=	pos;

		/*
		// we maken een referentie aan
		GameObject shootingTower	=	towers[index];

		// vervolgens laten we hem schieten
		shootingTower.GetComponent<TowerShooting>().Shoot();
		
		// plus we passen de yPositie aan
		Vector3 pos	=	shootingTower.transform.position;
		pos.y += 1;
		shootingTower.transform.position	=	pos;*/
	}

}
