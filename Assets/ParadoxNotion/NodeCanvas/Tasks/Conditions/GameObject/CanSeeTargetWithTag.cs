using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Conditions
{

    [Category("GameObject")]
    [Description("A combination of line of sight and view angle check")]
    public class CanSeeTargetWithTag : ConditionTask<Transform>
    {
        [TagField]
        public BBParameter<string> tag;
        public BBParameter<float> maxDistance = 50;
        public BBParameter<float> awarnessDistance = 0f;
        [SliderField(1, 180)]
        public BBParameter<float> viewAngle = 70f;
        public Vector3 offset;
        
        [BlackboardOnly]
        public BBParameter<GameObject> saveAs;

        private RaycastHit hit;

        protected override string info {
            get { return "Can See tag" + saveAs; }
        }

        protected override bool OnCheck()
        {
            var list = GameObject.FindGameObjectsWithTag(tag.value);
            Debug.Log(tag.value);
            Debug.Log(list.Length);
            foreach (var target in list)
            {
                var t = target.transform;
                if ( Vector3.Distance(agent.position, t.position) > maxDistance.value ) {
                    return false;
                }

                if ( Physics.Linecast(agent.position + offset, t.position + offset, out hit) ) {
                    if ( hit.collider != t.GetComponent<Collider>() ) {
                        return false;
                    }
                }

                if ( Vector3.Angle(t.position - agent.position, agent.forward) < viewAngle.value )
                {
                    saveAs.value = target;
                    return true;
                }

                if ( Vector3.Distance(agent.position, t.position) < awarnessDistance.value ) {
                    saveAs.value = target;
                    return true;
                }
            }
            return false;
        }

        public override void OnDrawGizmosSelected() {
            if ( agent != null ) {
                Gizmos.DrawLine(agent.position, agent.position + offset);
                Gizmos.DrawLine(agent.position + offset, agent.position + offset + ( agent.forward * maxDistance.value ));
                Gizmos.DrawWireSphere(agent.position + offset + ( agent.forward * maxDistance.value ), 0.1f);
                Gizmos.DrawWireSphere(agent.position, awarnessDistance.value);
                Gizmos.matrix = Matrix4x4.TRS(agent.position + offset, agent.rotation, Vector3.one);
                Gizmos.DrawFrustum(Vector3.zero, viewAngle.value, 5, 0, 1f);
            }
        }
    }
}