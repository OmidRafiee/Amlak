using System;
using DNTPersianUtils.Core;

namespace Exir.Regate
{
    public static class RegatePersianDatePicker2
    {
        public static string Build(string name, DateTime? value = null, bool isRequired = true)
        {
            var uniqueId = "RegatePersianDatePicker2__" + name + "__" + Guid.NewGuid().ToString().Replace("-", "");
            var uniqueIdPicker = uniqueId + "__picker";
            var uniqueIdHidden = uniqueId + "__hidden";

            var defaultDateJalali = "";

            if (value != null)
                defaultDateJalali = ((DateTime) value).ToPersianDateTimeString("yyyy/MM/dd");


            var markup = $@"

                <script src='/lib/jquery-calendars-2.0.0/jquery.calendars.min.js'></script>
                <script src='/lib/jquery-calendars-2.0.0/jquery.calendars.plus.js'></script>
                <script src='/lib/jquery-calendars-2.0.0/jquery.calendars.persian.min.js'></script>
                <script src='/lib/jquery-calendars-2.0.0/jquery.calendars.persian-fa.js'></script>
                <script src='/lib/jquery-calendars-2.0.0/jquery.plugin.min.js'></script>
                <script src='/lib/jquery-calendars-2.0.0/jquery.calendars.picker.min.js'></script>
                <script src='/lib/jquery-calendars-2.0.0/jquery.calendars-fa.js'></script>
                <script src='/lib/jquery-calendars-2.0.0/jquery.calendars.picker-fa.js'></script>
                <link rel='stylesheet' type='text/css' href='/lib/jquery-calendars-2.0.0/jquery.calendars.picker.css' />

                <input type='text'
                    id='{uniqueIdPicker}'
                    readonly='readonly'
                    class='form-control'
                    data-role='persian-date-picker'
                />

                <input type='text'
                    {(isRequired ? " required='required' " : "")}
                    id='{uniqueIdHidden}'
                    name='{name}'
                    style='opacity: 0; position: relative; z-index: -1; width: 0; height: 0; pointer-events: none; overflow: hidden; left: 50px;' tabindex='-1'
                />

                <script>
                    (function() {{
                        var name = '{name}';
                        var uniqueId = '{uniqueId}';
                        var uniqueIdPicker = '{uniqueIdPicker}';
                        var uniqueIdHidden = '{uniqueIdHidden}';
                        var $picker = $('#' + uniqueIdPicker);
                        var $hidden = $('#' + uniqueIdHidden);
                        var defaultDate = '{defaultDateJalali}';

                        var _defaultDate = defaultDate;
                        var _dateFormat = 'yyyy/mm/dd';
                        var _hiddenDateFormat = 'yyyy-mm-dd 00:00:00';

                        var options = {{
                            calendar: $.calendars.instance('persian', 'fa'),
                            dateFormat: _dateFormat,
                            selectDefaultDate: true,
                            useMouseWheel: false,
                            changeMonth: true,
                            showSpeed: 0,
                            yearRange:'c-100:c+100',
                            onSelect: function(dates) {{
                                var jd = dates[0].toJD();

                                var date = $.calendars.instance('gregorian').fromJD(jd);
                                $hidden.val(date.formatDate(_hiddenDateFormat));
                            }}
                        }};

                        if (_defaultDate != '') {{
                            options.defaultDate = _defaultDate;
                        }}

                        $picker.calendarsPicker(options);
                    }}());
                </script>
            ";

            return markup;
        }
    }
}