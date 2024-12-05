using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissHandler : MonoBehaviour
{
    [SerializeField] string currentStateStr;
    [SerializeField] DivingDuck divingDuck;
    [SerializeField] Player player;
    [SerializeField] Target target;
    [SerializeField] AnimationStateChanger animationStateChanger;

    // AI:
    delegate void AIState();
    AIState currentState;

    // trackers ===============================
    float stateTime = 0;
    bool justChangedState = false;



    // Start is called before the first frame update
    void Start()
    {
        currentState = Idle;

        player = target.GetPlayerInputHandler().GetPlayer();
        // currentState = FollowState;
    }

    public void OnTriggerExit2D(Collider2D other){

        if (other.CompareTag("Bullet")) // ensures object colliding is a bullet
        {
            if (this.CompareTag("Diver"))
            {
                Debug.Log("Miss!");
                ChangeState(AttackState);
                animationStateChanger.ChangeAnimationState("Diving");
            }
        }
    }    

    void ChangeState(AIState newAIState)
    {
        currentState = newAIState;
        justChangedState = true;
    }

    void Idle()
    {
        if(stateTime == 0)
        {
            currentStateStr = "Idle State";
        }
    }

    void AttackState()
    {
        if(stateTime == 0)
        {
            currentStateStr = "Attack State";
        }

        divingDuck.MoveToward(player.transform.position);
        divingDuck.AimDuck(player.transform);
    }


    void AITick()
    {
        if(justChangedState)
        {
            stateTime = 0;
            justChangedState = false;
        }
        currentState();
        stateTime += Time.deltaTime;
    }

    // Update is called once per frame
    void Update()
    {
        AITick();
    }
}
