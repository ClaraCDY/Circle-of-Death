using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Circle_of_Death
{
	class Program
	{
		static bool isStabbed = true;
		static Person stabber;
		static int numberLength;

		static void Main(string[] args)
		{
			Console.Title = "Circle of Death";
			Console.WriteLine("Enter the amount of people in the circle");
			int numberOfPeople = Convert.ToInt32(Console.ReadLine());
			numberLength = numberOfPeople.ToString().Length;
			Person[] people = new Person[numberOfPeople];
			for (int i = 0; i < people.Length; i++)
			{
				people[i] = new Person();
				people[i].GetSetPosition = i+1;
			}
			if (numberOfPeople == 1)
			{
				Random random = new Random();
				int chance = random.Next(2);
				if (chance == 1)
				{
					Console.WriteLine("They didn't commit seppuku. Shame.");
				}
				else
				{
					Console.WriteLine("They commited seppuku, no one lives.");
				}
				
				
			}
			else if(numberOfPeople > 1)
			{
				Console.WriteLine("Starting...\n\n");
				Person lastAlive = StartStabbing(people);
				Console.WriteLine("\nLast person alive was in position: "+lastAlive.GetSetPosition.ToString(string.Concat(Enumerable.Repeat("0", numberLength)))); 
			}
			else
			{
				Console.WriteLine("Nope.");
			}
			Console.ReadLine();
		}

		private static Person StartStabbing(Person[] people)
		{
			Random rand = new Random();
			string[] weapons = new string[5] {"shot", "stabbed", "punched", "burnt", "disembowelled"};
			foreach (Person personInQueue in people.Where(x=>x.GetSetDead == false))
			{
				string weapon = weapons[rand.Next(weapons.Length)];
				if (people.Count(x => x.GetSetDead == false) > 1)
				{
					if (isStabbed == false)
					{
						Console.Write(personInQueue.GetSetPosition.ToString(string.Concat(Enumerable.Repeat("0", numberLength))) + " has been");
						Console.ForegroundColor = ConsoleColor.Red;
						Console.Write(string.Format("{0, -15}", " " + weapon + " "));
						Console.ResetColor();
						Console.Write("by " + stabber.GetSetPosition.ToString(string.Concat(Enumerable.Repeat("0", numberLength))) + "!\n");
						personInQueue.GetSetDead = true;
						isStabbed = true;
					}
					else
					{
						stabber = personInQueue;
						isStabbed = false;
					}
				}
				else
				{
					break;
				}
				
			}
			if (people.Count(x=>x.GetSetDead == false) > 1)
			{
				return StartStabbing(people);
			}
			else
			{
				return people.First(x => x.GetSetDead == false);
			}
		}

	}
}
