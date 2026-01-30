using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameDevTV.Inventories;

namespace GameDevTV.UI.Inventories
{
    /// <summary>
    /// To be placed on the root of the inventory UI. Handles spawning all the
    /// inventory slot prefabs.
    /// </summary>
    public class InventoryUI : MonoBehaviour
    {
        // CONFIG DATA
        [SerializeField] InventorySlotUI InventoryItemPrefab = null;

        // CACHE
        Inventory playerInventory;

        bool _hasBeenInitialized = false;

        // LIFECYCLE METHODS

        private void Awake()
        {
            playerInventory = Inventory.GetPlayerInventory();
            
        }

        private void Start()
        {
            playerInventory.OnInventoryUpdated += Redraw;
            Redraw();
        }

        // PRIVATE
        // OLD VERSION
        /*private void Redraw()
        {
            foreach (Transform child in transform)
            {
                Destroy(child.gameObject);
            }

            for (int i = 0; i < playerInventory.Size; i++)
            {
                var itemUI = Instantiate(InventoryItemPrefab, transform);
                itemUI.Setup(playerInventory, i);
            }
        }*/

        private void Redraw()
        {
            if (!_hasBeenInitialized)
            {
                foreach (Transform child in transform)
                {
                    Destroy(child.gameObject);
                }

                for (int i = 0; i < playerInventory.Size; i++)
                {
                    var itemUI = Instantiate(InventoryItemPrefab, transform);
                    itemUI.Setup(playerInventory, i);
                }
                _hasBeenInitialized = true;
            }
            else
            {
                foreach (InventorySlotUI itemUI in transform.GetComponentsInChildren<InventorySlotUI>())
                {
                    itemUI.Refresh();
                }
            }
        }
    }
}