namespace Exir.Regate
{
    public static class RegateImage
    {
        public static string Build(string name = "", string value = "", bool isRequired = false)
        {
            var defaultImageValue = "";
            if (!string.IsNullOrWhiteSpace(value))
            {
                defaultImageValue += $"document.getElementById('fileupload__image__{name}').src = window.__Configuration['RepositoryUrl'] + '{value}';";
                defaultImageValue += $"document.getElementById('fileupload__image__remove__{name}').style.display = '';";
            }

            var markup = $@"
                <input type='text' style='display: none;' id='image-field-{name}' name='{name}' value='{value}' />


                <a href='/file/image/?field={name}'
                   onclick='PopupCenter(this.href, ""ScyllaUploadFile"", 400, 600); return false;'
                   class='btn btn-default red-flamingo'
                   id='uploadFileButton__{name}'
                >انتخاب عکس</a>

                <button type='button' class='btn btn-default' style='display: none;' id='fileupload__image__remove__{name}'>حذف عکس</button>

                <div style='margin-top: 5px;'>
                    <img id='fileupload__image__{name}' src='' />
                </div>

                <script>
                    {defaultImageValue}

                    window['__setImage_{name}'] = function (fileName) {{
                        document.getElementById('image-field-{name}').value = fileName;
                        document.getElementById('fileupload__image__{name}').src = window.__Configuration['RepositoryUrl'] + fileName;
                        document.getElementById('fileupload__image__{name}').style.display = '';
                        document.getElementById('fileupload__image__remove__{name}').style.display = '';
                    }};
                    
                    document.getElementById('fileupload__image__remove__{name}').onclick = function () {{
                        document.getElementById('image-field-{name}').value = '';
                        document.getElementById('fileupload__image__{name}').src = '';
                        document.getElementById('fileupload__image__{name}').style.display = 'none';
                        document.getElementById('fileupload__image__remove__{name}').style.display = 'none';
                    }};
                </script>

                <style>
                    #fileupload__image__{name} {{
                        max-width: 300px;
                        max-height: 300px;
                    }}
                </style>
            ";

            return markup;
        }
    }
}
