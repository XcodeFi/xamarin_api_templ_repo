using FirebaseNet.Messaging;
using Newtonsoft.Json;

namespace apiFirebaseNet
{
   internal   class iOSNotification : INotification
    {
        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }
        [JsonProperty(PropertyName = "body")]
        public string Body { get; set; }
        [JsonProperty(PropertyName = "icon")]
        public string Icon { get; set; }
        [JsonProperty(PropertyName = "sound")]
        public string Sound { get; set; }
        [JsonProperty(PropertyName = "tag")]
        public string Tag { get; set; }
        [JsonProperty(PropertyName = "color")]
        public string Color { get; set; }
        [JsonProperty(PropertyName = "click_action")]
        public string ClickAction { get; set; }
        [JsonProperty(PropertyName = "body_loc_key")]
        public string BodyLocKey { get; set; }
        [JsonProperty(PropertyName = "body_loc_args")]
        public string BodyLocArgs { get; set; }
        [JsonProperty(PropertyName = "title_loc_key")]
        public string TitleLocKey { get; set; }
        [JsonProperty(PropertyName = "title_loc_args")]
        public string TitleLocArgs { get; set; }
    }
}