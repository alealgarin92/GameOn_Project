using AnythingWorld.Utilities;
using AnythingWorld.Utilities.Data;
using System.Collections.Generic;
using System.Linq;
using AnythingWorld.Behaviour.Tree;

using UnityEngine;

namespace AnythingWorld.Behaviour
{
    public static class BehaviourHandler
    {
        public static void AddBehaviours(ModelData data)
        {
            var wasDefaultBehaviourSet = false;
            
            if (data.parameters.categorizedBehaviours != null)
            {
                wasDefaultBehaviourSet = TrySetBehaviour(data, data.parameters.categorizedBehaviours);
            }

            if (data.parameters.setDefaultBehaviourPreset && !wasDefaultBehaviourSet)
            {
                if (data.parameters.defaultBehaviourPreset != null)
                {
                    wasDefaultBehaviourSet = TrySetBehaviourTree(data, data.parameters.defaultBehaviourPreset);
                }
                
                if (!wasDefaultBehaviourSet)
                {
                    var firstInstance = Resources.LoadAll<DefaultBehaviourPreset>("").FirstOrDefault();

                    if (firstInstance != null)
                    {
                        wasDefaultBehaviourSet = TrySetBehaviourTree(data, firstInstance);
                    }
                    else
                    {
                        Debug.LogWarning("Couldn't find DefaultBehaviourPreset in Resources to apply to model " +
                                  "(Do you need to create a preset in resources?)");
                    }

                    if (!wasDefaultBehaviourSet && data.animationPipeline != AnimationPipeline.Static)
                    {
                        Debug.LogWarning("Couldn't find a behaviour matching model's DefaultBehaviourType in " +
                                         "DefaultBehaviourPreset to apply to model. " +
                                         "Check if scripts for all behaviour types were set.");
                    }
                }
            }

            if (data.parameters.monoBehaviours != null)
            {
                foreach (var behaviour in data.parameters.monoBehaviours)
                {
                    data.model.AddComponent(behaviour);
                }
            }

            data.actions.postProcessingDelegate?.Invoke(data);
        }
        
        private static bool TrySetBehaviour(ModelData data, Dictionary<DefaultBehaviourType, System.Type> dict)
        {
            if (!dict.TryGetValue(data.defaultBehaviourType, out var scriptType))
            {
                return false;
            }
            
            data.model.AddComponent(scriptType);
            return true;
        }
       
        private static bool TrySetBehaviourTree(ModelData data, DefaultBehaviourPreset preset)
        {
            foreach (var rule in preset.behaviourRules)
            {
                if (rule.behaviourType != data.defaultBehaviourType)
                {
                    continue;
                }

                var behaviourTreeRunner = data.model.AddComponent<BehaviourTreeInstanceRunner>();
                behaviourTreeRunner.behaviourTree = rule.treeAsset;
                return true;
            }
            return false;
        }
    }
}
