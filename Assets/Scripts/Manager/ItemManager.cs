using System.Collections.Generic;
using Components.Item;
using Item;
using RFramework.Common.Singleton;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Manager
{
    public class ItemManager : MonoSingleton<ItemManager>
    {
        private const string PATH_PREFIX = "Items";

        private Dictionary<string, ItemData> _itemDic =
            new Dictionary<string, ItemData>();

        private void Update()
        {
            if (Keyboard.current.rKey.wasPressedThisFrame)
            {
                var player = GameManager.Contexts.game.playerTagEntity;
                player.ChangeItem(new ChangeItemPair
                {
                    ItemName = "BulletFindClosetTarget",
                    Type = ChangeItemType.Add
                });
            }
        }

        public ItemData GetItem(string itemName)
        {
            if (!_itemDic.TryGetValue(itemName, out var itemData))
            {
                itemData = Resources.Load<ItemData>(
                    $"{PATH_PREFIX}/{itemName}");
                if (itemData == null)
                {
                    Debug.LogError(
                        $"找不到名为{itemData}的Item资源");
                    return null;
                }

                _itemDic.Add(itemName, itemData);
            }

            return itemData;
        }
    }
}