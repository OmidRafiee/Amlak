using System;

namespace Exir.Regate
{
    public static class RegatePrice
    {
        public static string Build(string name = "", decimal? value = null, bool isRequired = false, bool debug = false)
        {
            // var uniqueId = $"RegatePrice__{name.Replace(".", "_")}__{Guid.NewGuid().ToString().Replace("-", "")}";
            var valueString = string.Format("{0:n0}", value);

            var scriptTag = @"
                <script>
                    $(function () {
                        function commaSeperate(number) {
                            var reversedString = number.split('').reverse().map(function (v, i) {
                                var comma = (i !== 0 && i % 3 === 0) ? ',' : '';
                                return v + comma;
                            });
                            return reversedString.reverse().join('');
                        }

                        function stripComma(number) {
                            var stripped = number.split('').filter(function(v) {
                                return v !== ',';
                            });
                            return stripped.join('');
                        }

                        $('[data-commasep=wrapper]').each(function() {
                            var origin = $(this).find('[data-commasep=origin]');
                            var show = $(this).find('[data-commasep=show]');

                            show.off('input.RegatePrice')
                                .on('input.RegatePrice', function (e) {
                                    var value = e.target.value;
                                    console.log(value);
                                    show.val(commaSeperate(stripComma(value)));
                                    origin.val(stripComma(value));
                                });

                            show.trigger('input.RegatePrice');
                        });
                    });
                </script>
            ";

            var markup = $@"
                <span data-commasep='wrapper'>
                    <input data-commasep='show' type='text' dir='ltr' style='direction: ltr;' value='{valueString}' class='form-control' {(isRequired ? " required='required' " : "")} />
                    <input data-commasep='origin' type='{(debug ? "text" : "hidden")}' name='{name}' value='{valueString}' class='form-control' />
                </span>
            ";

            return scriptTag + markup;
        }
    }
}
