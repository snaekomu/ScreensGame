using UnityEngine;
using System.Collections;

public class animatorBehaviour : StateMachineBehaviour {

	// OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		animator.SetBool ("Yellable", animator.GetComponentInParent<peepController> ().Yellable);
	}
}
