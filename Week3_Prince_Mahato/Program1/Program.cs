using System.Transactions;
using static Item;

class Item
{
	protected struct Items
	{
		public int id;
		public string name;
		public int price;
		public int quantity;
	}
	protected List<Items> list = new List<Items>();
}

class ItemFunction : Item
{
	public void addItem()
	{
		Items temp = new Items();
		try
		{
			Console.WriteLine("Enter the Id: ");
			temp.id = Convert.ToInt32(Console.ReadLine());
			Console.WriteLine("Name: ");
			temp.name = Console.ReadLine();
			Console.WriteLine("Price: ");
			temp.price = Convert.ToInt32(Console.ReadLine());
			Console.WriteLine("Quantity: ");
			temp.quantity = Convert.ToInt32(Console.ReadLine());
		}
		catch (Exception e)
		{
			Console.WriteLine("ERROR: please Enter a number");
		}

		list.Add(temp);
	}

	public void displayItem()
	{
        foreach (var item in list)
        {
			Console.WriteLine("\nId:" + item.id + " Name:" + item.name + " Price:" + item.price + " Quantity:" + item.price);
        }
    }

	public void findItem(int id)
	{
		foreach (var item in list)
		{
			if(item.id == id)
			{
				Console.WriteLine("\nName:" + item.name + " Price:" + item.price + " Quantity:" + item.price);
				return;
			}
		}
		Console.WriteLine("No item Present with id: " + id);
	}

	public void updateItem()
	{
		Console.WriteLine("Enter the id you want to update: ");
		int id = Convert.ToInt32(Console.ReadLine());
		foreach (var item in list)
		{ 
			if (item.id == id)
			{
				Items temp = new Items();
				temp.id = id;
				try
				{
					Console.WriteLine("Name: ");
					temp.name = Console.ReadLine();
					Console.WriteLine("Price: ");
					temp.price = Convert.ToInt32(Console.ReadLine());
					Console.WriteLine("Quantity: ");
					temp.quantity = Convert.ToInt32(Console.ReadLine());
				}
				catch (Exception e)
				{
					Console.WriteLine("ERROR: please Enter a number");
				}
				list.Remove(item);
				list.Add(temp);
				return;
			}
		}

		Console.WriteLine("No item Present with id: " + id);
	}

	public void deleteItem()
	{
		Console.WriteLine("Enter the id you want to delete: ");
		int id = Convert.ToInt32(Console.ReadLine());
		foreach (var item in list)
		{
			if(item.id == id)
			{
				list.Remove(item);
				return;
			}
		}
	}
}

class Program
{
	public static void Main(string[] args)
	{
		ItemFunction itm = new ItemFunction();
		Boolean cond = true;
		while (cond)
		{
			Console.WriteLine("Choose: \n  1.Add Item\n  2.Display Item\n  3.Find By item\n  4.Update Item\n  5.Delete Item\n 6.Exit");
			int select = Convert.ToInt32(Console.ReadLine());
			switch (select)
			{
				case 1:
					itm.addItem();
					break;
				case 2:
					itm.displayItem();
					break;
				case 3:
					Console.WriteLine("Enter the id: ");
					int id = Convert.ToInt32(Console.ReadLine());
					itm.findItem(id);
					break;
				case 4:
					itm.updateItem();
					break;
				case 5:
					itm.deleteItem();
					break;
				case 6:
					cond = false;
					break;
				default:
					Console.WriteLine("Please enter correct option");
					break;
			}
			Console.WriteLine("\n");
		}
	}
}