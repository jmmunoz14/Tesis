using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Obi;

[RequireComponent(typeof(ObiSolver))]
public class FluidNutrientsCollisionHandler : MonoBehaviour {

	ObiSolver solver;
	NutrientLandController nutrientsController;

	void Awake(){
		solver = GetComponent<Obi.ObiSolver>();
	}

	void OnEnable () {
		solver.OnCollision += Solver_OnCollision;
	}

	void OnDisable(){
		solver.OnCollision -= Solver_OnCollision;
	}

	void Solver_OnCollision (object sender, Obi.ObiSolver.ObiCollisionEventArgs e)
	{
		foreach(Oni.Contact contact in e.contacts)
		{
			if (contact.distance < 0.001f)
			{
				Component collider;


				if (ObiCollider.idToCollider.TryGetValue(contact.other, out collider)){

					nutrientsController = collider.GetComponent<NutrientLandController>();
					nutrientsController.safeLand();
				}
			}
		}

	}



}

