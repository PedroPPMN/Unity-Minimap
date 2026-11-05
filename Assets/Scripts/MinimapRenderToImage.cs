using UnityEngine;
using UnityEngine.UI;

namespace Portfolio.Minimap
{
    public sealed class MinimapRenderToImage : MonoBehaviour
    {
        [SerializeField] private Camera mapCamera;
        [SerializeField] private RawImage targetImage;
        [SerializeField] private int resolution = 256;

        private RenderTexture _rt;

        private void Awake()
        {
            if (mapCamera == null || targetImage == null) return;

            _rt = new RenderTexture(resolution, resolution, 16);
            mapCamera.targetTexture = _rt;
            targetImage.texture = _rt;
        }

        private void OnDestroy()
        {
            if (mapCamera != null) mapCamera.targetTexture = null;
            if (_rt != null)
            {
                _rt.Release();
                Destroy(_rt);
            }
        }
    }
}