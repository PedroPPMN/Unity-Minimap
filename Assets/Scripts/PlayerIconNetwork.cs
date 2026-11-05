using UnityEngine;

namespace Portfolio.Minimap
{
    /// <summary>
    /// Network-agnostic player icon payload. Hook into Netcode NetworkVariable&lt;Vector3&gt;
    /// or your own sync layer. Kept free of NGO package references so the demo compiles alone.
    /// </summary>
    public sealed class PlayerIconNetwork : MonoBehaviour
    {
        [SerializeField] private string playerDisplayName = "Player";
        [SerializeField] private Color iconColor = Color.cyan;

        public string PlayerDisplayName => playerDisplayName;
        public Color IconColor => iconColor;
        public Vector3 SyncedPosition { get; private set; }

        public void PublishPosition(Vector3 worldPosition)
        {
            SyncedPosition = worldPosition;
            transform.position = worldPosition;
        }
    }
}