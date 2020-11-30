using MVVM_Organiser.ViewModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM_Organiser.Model
{
	class FileIOServiceModel
	{
		private readonly string PATH;
		public FileIOServiceModel(string path)
		{
			PATH = path;
		}
		public BindingList<ToDoViewModel> LoadData()
		{
			var fileExists = File.Exists(PATH);
			if (!fileExists)
			{
				File.CreateText(PATH).Dispose();
				return new BindingList<ToDoViewModel>();
			}
			using (var reader = File.OpenText(PATH))
			{
				var fileText = reader.ReadToEnd();
				return JsonConvert.DeserializeObject<BindingList<ToDoViewModel>>(fileText);
			}
		}
		public void SaveData(object todoDataList)
		{
			using (StreamWriter writer = File.CreateText(PATH))
			{
				string output = JsonConvert.SerializeObject(todoDataList);
				writer.Write(output);
			}
		}
	}
}
