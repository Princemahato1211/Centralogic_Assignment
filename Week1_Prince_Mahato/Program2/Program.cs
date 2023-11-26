internal class Program
{
	public static void Main(string[] args)
	{
		Console.WriteLine("Enter a number: ");
		string str_num1 = Console.ReadLine();
		Console.WriteLine("Enter a number: ");
		string str_num2 = Console.ReadLine();

		try
		{
			int num1 = Convert.ToInt32(str_num1);
			int num2 = Convert.ToInt32(str_num2);
			Console.WriteLine("Square os Sum of both numbers are: " + Math.Pow(num1 + num2, 2));
		}
		catch (Exception e)
		{
			Console.WriteLine("PLease Enter a valid number");
		}

		
		
	}
}