using System;

namespace Exir.Regate
{
    public static class RegatePersianDatePicker
    {
        public static string Build(string name, DateTime? value = null, bool isRequired = false)
        {
            if (!value.HasValue || value.Value.Year == 1)
            {
                value = DateTime.Now;
            }
            var markup = $@"

                <input type='text' id='{name}_Id' name='{name}_Id' {(isRequired ? " required='required' " : "")} class='pdate' />
                <input type='hidden' id='{name}' name='{name}' />
               
                <script>
          
    (function() {{
                var calObj = new AMIB.persianCalendar('{name}_Id',
            {{
                extraInputID: '{name}',
                extraInputFormat: 'YYYY/MM/DD',
                initialDate: calculateDate()
            }});

            function calculateDate() {{
             
                var persianDate = '';

                    var year  ='{value.Value.Year}';
                    var month ='{value.Value.Month}';
                    var day   ='{value.Value.Day}';

                persianDate = new JalaliDate.gregorianToJalali(year, month, day);
                return persianDate;
                }}
            }}());

                </script>";

            return markup;
        }
    }
}