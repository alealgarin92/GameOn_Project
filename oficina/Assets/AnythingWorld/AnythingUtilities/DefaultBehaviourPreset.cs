using System.Collections.Generic;
using AnythingWorld.Behaviour.Tree;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace AnythingWorld.Utilities
{
    [System.Serializable]
    [CreateAssetMenu(fileName = "DefaultBehaviours", menuName = "ScriptableObjects/DefaultBehaviour", order = 1)]
    public class DefaultBehaviourPreset : ScriptableObject
    {
        [SerializeField] public List<BehaviourRule> behaviourRules = new List<BehaviourRule>();
        
        private void OnEnable()
        {
#if UNITY_EDITOR
            AssetDatabase.importPackageCompleted += SetupDefaultBehaviourPreset;
#else
            SetupDefaultBehaviourPreset("");
#endif
        }

        private void SetupDefaultBehaviourPreset(string packageName)
        {
            TransformSettings.GetInstance();
            behaviourRules = new List<BehaviourRule>();
#if UNITY_EDITOR
            if (TransformSettings.StaticBehaviourTree != null) behaviourRules.Add(new BehaviourRule(DefaultBehaviourType.Static, TransformSettings.StaticBehaviourTree));
            if (TransformSettings.NavMeshRiggedAnimalTree != null) behaviourRules.Add(new BehaviourRule(DefaultBehaviourType.NavMeshWalkingAnimal, TransformSettings.NavMeshRiggedAnimalTree));
            if (TransformSettings.RiggedAnimalTree != null) behaviourRules.Add(new BehaviourRule(DefaultBehaviourType.WalkingAnimal, TransformSettings.RiggedAnimalTree));
            if (TransformSettings.GroundVehicleTree != null) behaviourRules.Add(new BehaviourRule(DefaultBehaviourType.WheeledVehicle, TransformSettings.GroundVehicleTree));
            if (TransformSettings.FlyingVehicleTree != null) behaviourRules.Add(new BehaviourRule(DefaultBehaviourType.FlyingVehicle, TransformSettings.FlyingVehicleTree));
            if (TransformSettings.FlyingAnimalTree != null) behaviourRules.Add(new BehaviourRule(DefaultBehaviourType.FlyingAnimal, TransformSettings.FlyingAnimalTree));
            if (TransformSettings.SwimmingAnimalTree != null) behaviourRules.Add(new BehaviourRule(DefaultBehaviourType.SwimmingAnimal, TransformSettings.SwimmingAnimalTree));
#endif
        }
    }
    [System.Serializable]
    public class BehaviourRule
    {
        [SerializeField]
        public DefaultBehaviourType behaviourType;
        [SerializeField]
        public BehaviourTree treeAsset;
        public BehaviourRule(DefaultBehaviourType _behaviourType, BehaviourTree _treeAsset)
        {
            behaviourType = _behaviourType;
            treeAsset = _treeAsset;
        }
    }
}
