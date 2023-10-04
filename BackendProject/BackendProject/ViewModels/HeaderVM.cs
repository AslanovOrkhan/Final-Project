using BackendProject.ViewModels.BasketViewModels;

namespace BackendProject.ViewModels
{
	public class HeaderVM
	{
		public Dictionary<string, string> Settings { get; set; }
		public BasketListVM Basket { get; set; }
		public int Count { get; set; }
	}
}
