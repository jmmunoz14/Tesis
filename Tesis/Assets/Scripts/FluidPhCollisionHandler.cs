using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Obi;

[RequireComponent(typeof(ObiSolver))]
public class FluidPhCollisionHandler : MonoBehaviour {

	ObiSolver solver;
	PhLandController phController;

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
		Oni.Contact contact = e.contacts[0];

		Component collider;
		if (ObiCollider.idToCollider.TryGetValue(contact.other,out collider)){
			phController = collider.GetComponent<PhLandController>();
			phController.increasePHLevel();
		}
	}



}

