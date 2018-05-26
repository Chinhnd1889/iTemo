namespace iTemo.jsGrid
{
    public class FieldEvent
    {
        public string EventName { get; set; }
        public string CallbackFunction { get; set; }

        public override string ToString()
        {
            return $"{{ EventName: \"{EventName}\", CallbackFunction: {CallbackFunction}}},";
        }
    }
}
