using UnityEngine;

namespace Portfolio.Minimap
{
    /// <summary>
    /// Orthographic top-down camera that follows a target for minimap rendering.
    /// </summary>
    public sealed class MapController : MonoBehaviour
    {
        [SerializeField] private Transform target;
        [SerializeField] private Camera mapCamera;
        [SerializeField] private float height = 30f;
        [SerializeField] private bool rotateWithTarget;

        private void LateUpdate()
        {
            if (target == null || mapCamera == null) return;

            var position = target.position;
            mapCamera.transform.position = new Vector3(position.x, position.y + height, position.z);
            mapCamera.transform.rotation = Quaternion.Euler(90f, rotateWithTarget ? target.eulerAngles.y : 0f, 0f);
        }

        public void SetTarget(Transform newTarget) => target = newTarget;
    }
}