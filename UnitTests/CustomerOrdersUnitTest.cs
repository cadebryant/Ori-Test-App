namespace UnitTests;
using static ConsoleApp1.Program;

[TestClass]
public class CustomerOrdersUnitTest
{

    [TestMethod]
    public void TestCalculateTotalSpent()
    {
        MyStackClass<Customer> stack = new MyStackClass<Customer>();
        var customer = new Customer { CustomerId = 1, FirstName = "FirstName 1", LastName = "LastName 1", Orders = PostOrders(7) };
        var totalCalculated = customer.CalculateTotalSpent();
        Assert.AreEqual<decimal>((decimal)14700, totalCalculated);
    }

    [TestMethod]
    public void TestStackBehavior()
    {
        MyStackClass<Customer> stack = new MyStackClass<Customer>();
        var customer = new Customer { CustomerId = 1, FirstName = "FirstName 1", LastName = "LastName 1", Orders = PostOrders(7) };
        stack.Push(customer);
        Assert.IsTrue(stack.Count() == 1);
        stack.Pop();
        Assert.AreEqual(stack.Count(), 0);
    }
}