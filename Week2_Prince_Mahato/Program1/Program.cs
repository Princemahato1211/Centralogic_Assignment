
using System.Collections;
using System.Collections.Generic;

internal class Program
{
	struct hero{
		public string title;
		public string description;
	}
	 
	public static void Main(string[] args)
	{
		List<hero> list = new List<hero>();
		Boolean cond = true;
		while(cond)
		{
			Console.WriteLine("Choose: \n  1.Create Task\n  2.Read Task\n  3.Update Task\n  4.Delete Task\n  5.Exit");
			int select = Convert.ToInt32(Console.ReadLine());
			switch (select)
			{
				case 1:
					addTask(list);
					break;
				case 2:
					readTask(list);
					break;
				case 3:
					updateTask(list);
					break;
				case 4:
					deleteTask(list);
					break;
				case 5:
					cond = false;
					break;
				default:
					Console.WriteLine("Please enter correct option");
					break;
			}
			Console.WriteLine("\n");
		}
	}

	static void addTask(List<hero> list)                             //to add task in list
	{
		Console.WriteLine("Enter the title of task: ");
		string title = Console.ReadLine();
		Console.WriteLine("Enter the Description of task: ");
		string descp = Console.ReadLine();

		hero temp = new hero();
		temp.title = title;
		temp.description = descp;

		list.Add(temp);
	}

	static void readTask(List<hero> list)                            // to read all task in list
	{
		Console.WriteLine("\n");
		int count = 1;
		foreach(var x in list){
			Console.WriteLine($"{count}Title: {x.title}\nDescription: {x.description}\n");
			count++;
		}
	}

	static void updateTask(List<hero> list)                           // to update  task in list
	{
		readTask(list);
		Console.WriteLine("\nEnter the Serial number of that task which you want Update: ");
		int num = Convert.ToInt32(Console.ReadLine());
		hero temp = new hero();

		Console.WriteLine("Do you want to change the title (y/n): ");
		string str = Console.ReadLine();
		if(str == "y" || str=="Y")
		{
			Console.WriteLine("Enter the new title: ");
			temp.title = Console.ReadLine();
		}else
		{
			temp.title = list[num-1].title;
		}

		Console.WriteLine("Do you want to change the Description (y/n): ");
		str = Console.ReadLine();
		if (str == "y" || str == "Y")
		{
			Console.WriteLine("Enter the new description: ");
			temp.description = Console.ReadLine();
		}else
		{
			temp.description = list[num - 1].description;
		}
		list.Remove(list[num-1]);
		list.Add(temp);

		Console.WriteLine("Updated Successfully");
	}

	static void deleteTask(List<hero> list)                         // to delete task from list
	{
		readTask(list);
		Console.WriteLine("\nEnter the Serial number of that task which you want delete: ");
		int num = Convert.ToInt32(Console.ReadLine());
		list.Remove(list[num - 1]);

		Console.WriteLine("Deleted Successfully");
	}

}

