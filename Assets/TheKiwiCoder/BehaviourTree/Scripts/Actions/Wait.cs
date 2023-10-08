using TheKiwiCoder;
using UnityEngine;

public class Wait : ActionNode {
    public float duration = 3;
    float startTime;

    protected override void OnStart() {
        startTime = Time.time;
        context.animator.SetBool("Wait",true);
    }

    protected override void OnStop() {
        context.animator.SetBool("Wait", false);
    }

    protected override State OnUpdate() {
        if (Time.time - startTime > duration) {
            return State.Success;
        }
        return State.Running;
    }
}

