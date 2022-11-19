using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Transform _hand;

    [SerializeField] private Inventory _inventory;
    private Item _inHand = null;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeRandomItem();
        }
    }

    private void TakeRandomItem()
    {
        if (_inventory.TryGetRandomItem(out Item item) == true)
        {
            TakeInHand(item);
        }
    }

    private void TakeInHand(Item item)
    {
        if (item == null)
            throw new NullReferenceException(nameof(item));

        if (_inHand != null)
            _inventory.AddItem(_inHand);

        _inHand = item;

        _inHand.transform.SetParent(_hand);
        _inHand.transform.localPosition = Vector3.zero;
        _inHand.transform.localRotation = Quaternion.identity;

        _inHand.gameObject.SetActive(true);
    }
}