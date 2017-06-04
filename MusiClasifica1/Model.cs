using System;
using Newtonsoft.Json.Linq;
namespace MusiClasifica1
{
	public class Model
	{
		public Model(string json)
		{
			JObject jObject = JObject.Parse(json);
			JToken jMovies = jObject["images"];
			this.Images = jMovies.ToString();
		}

		public string Images { get; set; }
	}
}