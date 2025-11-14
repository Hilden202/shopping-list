using ShoppingList.Application.Interfaces;
using ShoppingList.Domain.Models;

namespace ShoppingList.Application.Services;

public class ShoppingListService : IShoppingListService
{
    private ShoppingItem[] _items;

    private int _nextIndex;

    public int ItemCount { get; private set; }

    

    public ShoppingListService()
    {
        _items = new ShoppingItem[10];
        _nextIndex = 0;
        
        ItemCount = 0;
    }

    public IReadOnlyList<ShoppingItem> GetAll()
    {
        var result = new List<ShoppingItem>();
        
        for (int i = 0; i < _nextIndex; i++)
        {
            result.Add(_items[i]);
        }
        return result;
    }

    public ShoppingItem? GetById(string id)
    {
        foreach (var item in _items)
        {
            if (item.Id == id)
            {
                return item;
            }
        }
        // TODO: Students - Find and return the item with the matching id
        return null;
    }

    public ShoppingItem? Add(string name, int quantity, string? notes)
    {
        // Expand array if _nextIndex points to the last element
        if (_nextIndex == (_items.Length - 1))
        {
            Array.Resize<ShoppingItem>(ref _items, 2 * _items.Length);
        }
        var item = new ShoppingItem
        {
            Name = name,
            Quantity = quantity,
            Notes = notes,
        };
        
        _items[_nextIndex] = item;
        _nextIndex++;
        ItemCount++;
        
    // Return the created item
    return item;
    }

    public ShoppingItem? Update(string id, string name, int quantity, string? notes)
    {
        // TODO: Students - Implement this method
        // Return the updated item, or null if not found
        return null;
    }

    public bool Delete(string id)
    {
        // TODO: Students - Implement this method
        // Return true if deleted, false if not found
        return false;
    }

    public IReadOnlyList<ShoppingItem> Search(string query)
    {
        // TODO: Students - Implement this method
        // Return the filtered items
        return [];
    }

    public int ClearPurchased()
    {
        // TODO: Students - Implement this method
        // Return the count of removed items
        return 0;
    }

    public bool TogglePurchased(string id)
    {
        // TODO: Students - Implement this method
        // Return true if successful, false if item not found
        return false;
    }

    public bool Reorder(IReadOnlyList<string> orderedIds)
    {
        // TODO: Students - Implement this method
        // Return true if successful, false otherwise
        return false;
    }

    public ShoppingItem[] _TEST_items()
    {
        return _items;
    }


}