using System;

namespace Exir.Regate
{
    public static class RegateInteractiveBooleanState
    {
        public static string Build(int id, bool value, string url, string iconTrue, string iconFalse, string title = "", string titleTrue = "", string titleFalse = "")
        {
            var guid = Guid.NewGuid().ToString();
            var uniqueId = $"RegateInteractiveBooleanState__{id}__{guid}";

            return $@"
                <div style='white-space: nowrap; display: inline-block' id='@uniqueId' v-cloak>
                    <span id='{uniqueId}state__0' class='text-danger' style='display: none; cursor: pointer;' title='{(string.IsNullOrWhiteSpace(titleFalse) ? title : titleFalse)}'>
                        <i class='fa fa-{iconFalse}'></i>
                    </span>

                    <span id='{uniqueId}state__1' class='text-success' style='display: none; cursor: pointer;' title='{(string.IsNullOrWhiteSpace(titleTrue) ? title : titleTrue)}'>
                        <i class='fa fa-{iconTrue}'></i>
                    </span>

                    <span id='{uniqueId}state__loading'>
                        <i class='fa fa-spin fa-spinner'></i>
                    </span>
                </div>
                <script>
                    (function() {{
                        var container = document.getElementById('{uniqueId}');
                        var state_0 = document.getElementById('{uniqueId}state__0');
                        var state_1 = document.getElementById('{uniqueId}state__1');
                        var state_loading = document.getElementById('{uniqueId}state__loading');

                        state_loading.style.display = 'none';

                        var value = {value.ToString().ToLower()};
                        var id = '{id}';
                        var url = '{url}';

                        if (value) {{
                            state_1.style.display = '';
                        }} else {{
                            state_0.style.display = '';
                        }}

                        var changeState = function(id, status) {{
                            // hide current states
                            state_0.style.display = 'none';
                            state_1.style.display = 'none';

                            // show loading
                            state_loading.style.display = '';

                            // send ajax request
                            var data = {{ id: id, status: status }};
                            var request = $.post(url, data);
                            request.then(function(response) {{
                                if (!response.Succeed) return alert('خطا! لطفا مجددا تلاش کنید');

                                // hide loading
                                state_loading.style.display = 'none';

                                // show current state
                                if (response.Data) {{
                                    state_0.style.display = 'none';
                                    state_1.style.display = '';
                                }} else {{
                                    state_1.style.display = 'none';
                                    state_0.style.display = '';
                                }}
                            }});
                        }};

                        state_0.onclick = function() {{
                            changeState(id, true);
                        }};
                        state_1.onclick = function() {{
                            changeState(id, false);
                        }};
                    }}());
                </script>
            ";
        }
    }
}
