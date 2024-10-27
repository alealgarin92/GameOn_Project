namespace AnythingWorld.Utilities
{
    /// <summary>
    /// Represents the default behaviour type for a game asset.
    /// </summary>
    [System.Serializable]
    public enum DefaultBehaviourType
    {
        /// <summary>
        /// The default behaviour is for a static game asset.
        /// </summary>
        Static,
        
        /// <summary>
        /// The default behaviour is for a walking animal game asset.
        /// </summary>
        WalkingAnimal,
        
        /// <summary>
        /// The navmesh movement behaviour is for a walking animal game asset.
        /// </summary>
        NavMeshWalkingAnimal,

        /// <summary>
        /// The default behaviour is for a wheeled vehicle game asset.
        /// </summary>
        WheeledVehicle,

        /// <summary>
        /// The default behaviour is for a flying vehicle game asset.
        /// </summary>
        FlyingVehicle,

        /// <summary>
        /// The default behaviour is for a flying animal game asset.
        /// </summary>
        FlyingAnimal,

        /// <summary>
        /// The default behaviour is for a swimming animal game asset.
        /// </summary>
        SwimmingAnimal
    }
}
