using System.ComponentModel;

internal class Program
{
	public static void Main(string[] args)
	{
		Boolean choose = true;
		while(choose)
		{
			Console.WriteLine("Enter a first number: ");
			string str_num = Console.ReadLine();
			double num1 = Convert.ToDouble(str_num);

			Console.WriteLine("Enter a second number: ");
			str_num = Console.ReadLine();
			double num2 = Convert.ToDouble(str_num);

			Console.WriteLine("Choose: ");
			Console.WriteLine("  1.ADD");
			Console.WriteLine("  2.SUB");
			Console.WriteLine("  3.MUL");
			Console.WriteLine("  4.DIV");
			Console.WriteLine("  5.MODULUS");

			string select  = Console.ReadLine();  
			int num = Convert.ToInt32(select);     //Converting string into number

			switch (num)
			{
				case 1:
					Console.WriteLine("Addition of two number are: "+ num1+num2);
					break;
				case 2:
					Console.WriteLine("Subtraction of two number are: " + (num1-num2));
					break;
				case 3:
					Console.WriteLine("Multiplication of two number are: " + num1*num2);
					break;
				case 4:
					Console.WriteLine("Division of two number are: " +num1/num2 );
					break;
				case 5:
					Console.WriteLine("Modulus of two number are: " +num1%num2);
					break;
			}

			Console.WriteLine("Do You Want to Continue (y/n): ");
			string sel = Console.ReadLine();
			if(sel == "n")
			{
				choose = false;
			}
		}
	}
}