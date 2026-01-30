using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using GameDevTV.Inventories;
using GameDevTV.Core.UI.Dragging;

namespace GameDevTV.UI.Inventories
{
    public class InventorySlotUI : MonoBehaviour, IDragContainer<InventoryItem>
    {
        // CONFIG DATA
        [SerializeField] InventoryItemIcon _icon = null;

        // STATE
        int _index;
        Inventory _inventory;

        // PUBLIC

        public void Setup(Inventory inventory, int index)
        {
            _inventory = inventory;
            _index = index;
            _icon.SetItem(inventory.GetItemInSlot(index));
        }

        public int MaxAcceptable(InventoryItem item)
        {
            if (_inventory.HasSpaceFor(item))
            {
                return int.MaxValue;
            }
            return 0;
        }

        public void AddItems(InventoryItem item, int number)
        {
            _inventory.AddItemToSlot(_index, item);
        }

        public InventoryItem GetItem()
        {
            return _inventory.GetItemInSlot(_index);
        }

        public void Refresh()
        {
            //icon.SetItem(inventory.GetItemInSlot(_index), inventory.GetNumberInSlot(_index)); future proofing for stackable items
            _icon.SetItem(_inventory.GetItemInSlot(_index));
        }

        public int GetNumber()
        {
            return 1;
        }

        public void RemoveItems(int number)
        {
            _inventory.RemoveFromSlot(_index);
        }
    }
}