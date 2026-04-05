using System;
namespace _10_GenericTypesCollections.Models
{
	public class Library<T>
	{
		public string Name { get; set; }
		public List<T> Items { get; set; }


		public Library(string name)
		{
			Name = name;
			Items = new List<T>();
		}
		public void Add(T item)
		{
			Items.Add(item);
			Console.WriteLine("elave edildi");
		}
        public void Remove(T item)
        {
            Items.Remove(item);
            Console.WriteLine("silindi");
        }
		public List<T> GetAll() => Items;

		public int count() => Items.Count;

		public T FindByIndex(int index)
		{
			if (index>=0 && index<Items.Count)
			{
				return Items[index];
			}
			return default(T);
		}


    }
}

