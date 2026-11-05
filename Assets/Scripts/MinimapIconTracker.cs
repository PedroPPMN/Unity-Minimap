using UnityEngine;

namespace Portfolio.Minimap
{
    /// <summary>
    /// Keeps a UI icon aligned with a world-space transform projected into minimap UV space.
    /// </summary>
    public sealed class MinimapIconTracker : MonoBehaviour
    {
        [SerializeField] private Transform worldTarget;
        [SerializeField] private RectTransform icon;
        [SerializeField] private Camera mapCamera;
        [SerializeField] private RectTransform mapImageRect;

        private void LateUpdate()
        {
            if (worldTarget == null || icon == null || mapCamera == null || mapImageRect == null) return;

            var viewport = mapCamera.WorldToViewportPoint(worldTarget.position);
            var anchored = new Vector2(
                (viewport.x - 0.5f) * mapImageRect.rect.width,
                (viewport.y - 0.5f) * mapImageRect.rect.height);
            icon.anchoredPosition = anchored;
            icon.gameObject.SetActive(viewport.z > 0f);
        }
    }
}