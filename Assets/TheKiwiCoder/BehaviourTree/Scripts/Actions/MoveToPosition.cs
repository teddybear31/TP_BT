using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;

public class MoveToPosition : ActionNode
{
    public float stoppingDistance = 0.1f;
    public bool updateRotation = true;
    public float tolerance = 0.01f;

    protected override void OnStart() {
        context.agent.stoppingDistance = stoppingDistance;
        context.agent.destination = blackboard.moveToPosition;
        context.agent.updateRotation = updateRotation;
        context.animator.SetBool("Walk",true);
    }

    protected override void OnStop() {
        context.animator.SetBool("Walk", false);
    }

    protected override State OnUpdate() {
        if (context.agent.pathPending) {
            return State.Running;
        }

        if (context.agent.remainingDistance < tolerance) {
            context.transform.position = new Vector3(blackboard.moveToPosition.x, context.transform.position.y, blackboard.moveToPosition.z);
            return State.Success;
        }

        if (context.agent.pathStatus == UnityEngine.AI.NavMeshPathStatus.PathInvalid) {
            return State.Failure;
        }

        return State.Running;
    }
}
