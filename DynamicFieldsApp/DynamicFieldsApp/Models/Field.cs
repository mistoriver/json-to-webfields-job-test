namespace DynamicFieldsApp.Models
{
    public class Field
    {
        private string _type;
        public string Title { get; set; }
        public string Type
        {
            get => _type;
            set
            {
                if (value == "text" || value == "select" || value == "textarea" || value == "datetime")
                    _type = value;
                else 
                    _type = "unknown";
            }
        }

        
        public bool Required { get; set; }
    }
}
