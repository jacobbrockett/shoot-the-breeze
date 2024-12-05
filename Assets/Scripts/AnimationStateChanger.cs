using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationStateChanger : MonoBehaviour
{
    // public enum AnimationState{Idle, Walk}; // Enumeration!!
    // [SerializeField] AnimationState currentEnumState = AnimationState.Idle; 
    [SerializeField] Animator animator;
    [SerializeField] string currentState = "Flying";

    public void ChangeAnimationState(string newState, float speed = 1f){
        if(currentState == newState){
            return;
        }

        currentState = newState;
        animator.speed = speed;
        animator.Play(currentState);
    }
}
