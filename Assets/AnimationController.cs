using UnityEngine;
using System.Collections;

public class AnimationController : MonoBehaviour {

    private Animator animator;

    void Awake()
    {
        animator = GetComponent<Animator>();
    }
    
	// Update is called once per frame
	void Update () {
	    if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            animator.SetBool("Active", !animator.GetBool("Active"));
        }
	}
}
