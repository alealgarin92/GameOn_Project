using UnityEngine;

namespace AnythingWorld.PostProcessing
{
    public static class ModelDimensionsUtility
    {
        public static bool TryGetDimensions(Transform tr, out Vector3 extents, out Vector3 center)
        {
            extents = Vector3.zero;
            center = Vector3.zero;
            
            var globalScale = tr.lossyScale;
            float x = 0, y = 0, z = 0;
            
            if (tr.TryGetComponent<BoxCollider>(out var boxCollider))
            {
                extents = Vector3.Scale(boxCollider.size, tr.lossyScale) / 2;
                center = tr.TransformPoint(boxCollider.center);
                return true;
            }
            
            if (tr.TryGetComponent<CapsuleCollider>(out var capsuleCollider))
            {
                //The value can be 0, 1 or 2 corresponding to the X, Y and Z axes, respectively.
                switch (capsuleCollider.direction)
                {
                    case 0:
                        x = capsuleCollider.height / 2;
                        y = z = capsuleCollider.radius;
                        break;
                    case 1:
                        x = z = capsuleCollider.radius;
                        y = capsuleCollider.height / 2;
                        break;
                    case 2:
                        x = y = capsuleCollider.radius;
                        z = capsuleCollider.height / 2;
                        break;
                }

                x *= globalScale.x;
                y *= globalScale.y;
                z *= globalScale.z;
                
                extents = new Vector3(x, y, z);
                center = tr.TransformPoint(capsuleCollider.center);
                
                return true;
            }
            
            if (tr.TryGetComponent<MeshFilter>(out var meshFilter))
            {
                extents = Vector3.Scale(meshFilter.mesh.bounds.size, tr.lossyScale) / 2;
                center = tr.TransformPoint(meshFilter.mesh.bounds.center);
                return true;
            }

            return false;
        }
    }
}
