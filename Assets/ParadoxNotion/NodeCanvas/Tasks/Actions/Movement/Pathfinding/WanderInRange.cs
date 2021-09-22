using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using UnityEngine.AI;

namespace NodeCanvas.Tasks.Actions
{
    
/**
 * 邢晨旭自定义
 */
    [Category("Movement/Pathfinding")]
    [Description("指定范围移动")]
    public class WanderInRange : ActionTask<NavMeshAgent>
    {
        public BBParameter<float> speed = 4;
        // public BBParameter<float> keepDistance = 0.1f;
        public BBParameter<Vector3> targetPos;
        public BBParameter<float> wanderDistance = 20;
        public BBParameter<float> delay = 0;
        public bool repeat = true;

        private float flag = 0f;
        private bool isFirst = true;

        protected override void OnExecute()
        {
            agent.speed = speed.value;
            DoWander();
        }

        protected override void OnUpdate()
        {
            // if (!agent.pathPending && agent.remainingDistance <= agent.stoppingDistance + keepDistance.value)
            if (!agent.pathPending && agent.remainingDistance <= agent.stoppingDistance)
            {
                if (repeat)
                {
                    if (flag >= delay.value || isFirst)
                    {
                        DoWander();
                    }
                }
                else
                {
                    EndAction();
                }

                flag += Time.deltaTime;
            }
        }

        void DoWander()
        {
            flag = 0f;
            var wanderPos = (Random.insideUnitSphere * wanderDistance.value) + targetPos.value;
            NavMeshHit hit;
            if (NavMesh.SamplePosition(wanderPos, out hit, agent.height * 2, NavMesh.AllAreas))
            {
                agent.SetDestination(hit.position);
            }

            if (isFirst)
            {
                isFirst = false;
            }
        }

        protected override void OnPause()
        {
            OnStop();
        }

        protected override void OnStop()
        {
            if (agent != null && agent.gameObject.activeSelf)
            {
                agent.Warp(agent.transform.position);
                agent.ResetPath();
            }
        }
    }
}