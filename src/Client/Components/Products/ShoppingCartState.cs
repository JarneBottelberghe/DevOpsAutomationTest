using Domain;

namespace Client.Components.Products
{
    public class ShoppingCartState
    {
        private ISet<Item> _items;
        public ShoppingCartState()
        {
            _items = new HashSet<Item>();
        }
        public ISet<Item> Items { get => _items; }

        public event Action OnChange;
        public event Action OnAdded;

        public void AddItem(Item item)
        {
            Item? i = _items.FirstOrDefault(i => i.ItemId == item.ItemId);
            if (i == null)
            {
                _items.Add(item);
            } else
            {
                PlusOne(i);
            }
            OnAdded?.Invoke();
        }
        public void RemoveItem(Item item)
        {
            _items.Remove(item);
            NotifyStateChanged();
        }

        public void MinusOne(Item item)
        {
            if(item.Quantity > 0)
            {
                item.Quantity--;
            }
            NotifyStateChanged();
        }

        public void PlusOne(Item item)
        {
            if(item.Product.LeftInStock > item.Quantity)
            {
                item.Quantity++;
                NotifyStateChanged();
            }
        }

        public void ClearItems() { 
            _items.Clear();
            NotifyStateChanged();
        }

        private void NotifyStateChanged() => OnChange?.Invoke();

    }
}
