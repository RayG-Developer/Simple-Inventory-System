using System;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] private Item[] _itemsPool;
    [SerializeField] private List<Item> _items = new List<Item>();

    private void Start()
    {
        CreateItems();
    }

    public bool TryGetRandomItem(out Item item)
    {
        item = null;

        while (item == null)
        {
            if (_items.Count <= 0)
                break;

            int randomItem = UnityEngine.Random.Range(0, _items.Count);
            item = _items[randomItem];
            _items.Remove(_items[randomItem]);
        }

        return item != null;
    }

    public void AddItem(Item item)
    {
        if (item == null)
            throw new NullReferenceException(nameof(item));

        item.gameObject.SetActive(false);
        item.transform.SetParent(transform);
        _items.Add(item);
    }

    private void CreateItems()
    {
        if (_itemsPool.Length > 0)
        {
            for (int i = 0; i < _itemsPool.Length; i++)
            {
                if (_itemsPool[i] != null)
                {
                    Item instrument = Instantiate(_itemsPool[i], transform.position, Quaternion.identity);
                    instrument.transform.SetParent(transform);
                    instrument.gameObject.SetActive(false);
                    _items.Add(instrument);
                }
            }
        }
    }
}
