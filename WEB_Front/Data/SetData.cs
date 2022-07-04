using Projects.Shared;

namespace WEB_Front.Data
{
    public class SetData
    {
        public String s = "https://localhost:7124/";
        private readonly HttpClient _http;
        public SetData() { }


        public async void SetListRating(Rating rat)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(s);
            await client.PostAsJsonAsync("api/Rating/", rat);
        }

    }
}
