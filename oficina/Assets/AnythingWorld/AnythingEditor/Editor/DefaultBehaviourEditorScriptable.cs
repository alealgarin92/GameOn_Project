using AnythingWorld.Behaviour.Tree;
using UnityEngine;

namespace AnythingWorld.Editor
{
    //[CreateAssetMenu(fileName = "DefaultBehaviours", menuName = "ScriptableObjects/DefaultBehaviour", order = 1)]
    public class DefaultBehaviourEditorScriptable : ScriptableObject
    {
        public BehaviourTree defaultNavMeshRigged;
        public BehaviourTree defaultRigged;
        public BehaviourTree defaultWheeledVehicle;
        public BehaviourTree defaultFlyingVehicle;
        public BehaviourTree defaultFlyingAnimal;
        public BehaviourTree defaultSwimmingAnimal;
    }
}
