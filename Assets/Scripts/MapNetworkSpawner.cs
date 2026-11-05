using System.Collections.Generic;
using UnityEngine;

namespace Portfolio.Minimap
{
    public sealed class MapNetworkSpawner : MonoBehaviour
    {
        [SerializeField] private PlayerIconNetwork iconPrefab;
        [SerializeField] private Transform iconsRoot;

        private readonly Dictionary<string, PlayerIconNetwork> _icons = new();

        public PlayerIconNetwork SpawnOrUpdate(string playerId, Vector3 position, Color color)
        {
            if (!_icons.TryGetValue(playerId, out var icon))
            {
                icon = Instantiate(iconPrefab, iconsRoot != null ? iconsRoot : transform);
                _icons[playerId] = icon;
            }

            icon.PublishPosition(position);
            return icon;
        }

        public void Despawn(string playerId)
        {
            if (!_icons.TryGetValue(playerId, out var icon)) return;
            Destroy(icon.gameObject);
            _icons.Remove(playerId);
        }
    }
}