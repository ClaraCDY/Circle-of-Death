using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Circle_of_Death
{
	public class Person
	{
		public bool GetSetDead { get; set; }
		public int GetSetPosition { get; set; }
		public Person()
		{
			GetSetDead = false; //Person is alive
		}
	}
}
