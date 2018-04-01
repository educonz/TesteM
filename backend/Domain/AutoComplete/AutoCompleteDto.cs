namespace Domain.AutoComplete
{
    public class AutoCompleteDto<TValue>
    {
        public string Label { get; set; }
        public TValue Value { get; set; }
    }
}
