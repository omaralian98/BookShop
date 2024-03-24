using System.Text.Json;
namespace Bookshop.Extra {
    public static class Extensions {
        public static void SetJson(this ISession session, string key, object value) {
            session.SetString(key, JsonSerializer.Serialize(value));
        }
        public static T? GetJson<T>(this ISession session, string key) {
            var sessionData = session.GetString(key);
            return sessionData == null ? default(T) : JsonSerializer.Deserialize<T>(sessionData);
        }
        public static string PathAndQuery(this HttpRequest request) => request.QueryString.HasValue
            ? $"{request.Path}{request.QueryString}" : request.Path.ToString();

        public static string ToImg(this byte[] data) {
            return string.Format("data:image/png;base64,{0}", Convert.ToBase64String(data));
        }
    }
}