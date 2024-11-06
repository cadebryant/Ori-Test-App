using System;
using System.Collections.Generic;

public class Customer
{
    public int CustomerId { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public DateTime RegistrationDate { get; set; }
    public List<Order> Orders { get; set; } = new List<Order>();

    public decimal CalculateTotalSpent()
    {
        decimal totalSpent = 0;
        foreach (var order in Orders)
        {
            totalSpent += order.TotalAmount;
        }
        return totalSpent;
    }
}

public class Order
{
    public int OrderId { get; set; }
    public DateTime OrderDate { get; set; }
    public List<OrderItem> Items { get; set; } = new List<OrderItem>();

    public decimal TotalAmount
    {
        get
        {
            decimal total = 0;
            foreach (var item in Items)
            {
                total += item.Price * item.Quantity;
            }
            return total;
        }
    }
}

public class OrderItem
{
    public string? ProductName { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }
}

public class MyStackClass<T>
{
    private List<T> items = new List<T>();
    public int Count()
    {
        return items.Count;
    }

    public void Push(T item)
    {
        if (item == null)
        {
            throw new ArgumentException($"{nameof(Push)}: {nameof(item)} cannot be null.");
        }
        items.Add(item);
    }

    public T Pop()
    {
        if (items.Count == 0)
            throw new InvalidOperationException("Stack is empty.");

        var lastIndex = items.Count - 1;
        var poppedItem = items[lastIndex];
        items.RemoveAt(lastIndex);
        return poppedItem;
    }

    public T Peek()
    {
        if (items.Count == 0)
            throw new InvalidOperationException("Stack is empty.");

        return items[items.Count - 1];
    }

    public bool IsEmpty()
    {
        return items.Count == 0;
    }
}