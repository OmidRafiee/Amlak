namespace Exir.Regate
{
    public static class RegateWysiwyg
    {
        public static string Build(string name = "", string value = "", bool isRequired = false)
        {
            var id = "RegateWysiwyg__" + name;

            var height = 500;

            return $@"
                <textarea
                    name='{name}'
                    id='{id}'
                    type='text'
                    class='form-control'
                    style='height: {height}px; resize: none'
                    {(isRequired ? " required='required' " : "")}
                >{value}</textarea>

                <script src='/lib/ckeditor/ckeditor.js'></script>

                <script>
                    (function () {{
                        if (typeof CKEDITOR === typeof undefined) {{
                            console.log('RegateWysiwyg needs ckeditor');
                            return;
                        }}
                        
                        function ckeditorIsLoaded() {{
                            if (typeof $.fn.matchHeight !== typeof undefined) {{
                                $.fn.matchHeight._update();
                            }}
                        }}

                        CKEDITOR.replace({id}, {{
                            language: 'fa',
                            height: '{height}px',
                            contentsLangDirection: 'rtl',
                            on: {{
                                instanceReady: function( evt ) {{
                                    ckeditorIsLoaded();
                                }}
                            }}
                        }});
                    }}());
                </script>
            ";
        }
    }
}
