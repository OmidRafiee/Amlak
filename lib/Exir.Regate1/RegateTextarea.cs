namespace Exir.Regate
{
    public static class RegateTextarea
    {
        public static string Build(string name = "", string value = "", bool isRequired = false, string placeholder = "")
        {
            return $@"<textarea
                name='{name}'
                type='text'
                class='form-control'
                placeholder='{placeholder}'
                style='height: 300px; resize: none;'
                {(isRequired ? " required='required' " : "")}
            >{value}</textarea>";
        }
    }
}
