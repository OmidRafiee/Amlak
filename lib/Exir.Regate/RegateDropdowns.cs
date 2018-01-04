using System;

namespace Exir.Regate
{
    public static class RegateDropdowns
    {
        public static string Build(
            string name = "",
            string url = "",
            string placeholder = "",
            string selectedValue = "",
            string sendAjaxValue = "",
            string sendAjaxParam = "id",
            string relatedDropdownName = "",
            bool required = true
        )
        {
            var uniqueId = $"RegateDropdowns__{name}__{Guid.NewGuid().ToString()}";

            return $@"
				<div style='text-align: center;'
                     data-cdd='{name}'
                     data-url='{url}'
                     data-placeholder='{placeholder}'
                     data-selected-value='{selectedValue}'
                     data-sendajax-value='{sendAjaxValue}'
                     data-sendajax-param='{sendAjaxParam}'
                     {(! string.IsNullOrWhiteSpace(relatedDropdownName) ? $"data-has-related-dropdown='{relatedDropdownName}'" : "")}
                >
                    <i class='fa fa-spin fa-spinner' data-role='loader' style='position: relative; top: 8px; display: none;'></i>
                    <select name='{name}' {(required ? " required='required' " : "")} style='display: none;' class='form-control'></select>
                </div>
            ";
        }

        public static string Initialize()
        {
            return @"
                <script>
                    $(function () {
                        if (window.__RegateDropdownsInitialized) {
                            console.log('tried to initialize RegateDropdowns more than once. Please check your page.');
                            return;
                        }

                        window.__RegateDropdownsInitialized = true;

                        function fillDropdown(name) {
                            // console.log('build dropdown for :', name);
                            var $container = $('[data-cdd=\'' + name + '\']');

                            if ($container.length == 0) return;

                            var $dd = $container.find('select');
                            var $loader = $container.find('[data-role=\'loader\']');
                            var url = $container.attr('data-url');
                            var sendajaxValue = $container.attr('data-sendajax-value');
                            var sendajaxParam = $container.attr('data-sendajax-param');
                            var selectedValue = $container.attr('data-selected-value');
                            var placeholder = $container.attr('data-placeholder');

                            // loading
                            $dd.hide();
                            $loader.hide();

                            hideRelatedDropdowns(name);

                            if (sendajaxValue == '') return;

                            $loader.show();

                            // send ajax request
                            var data = {};
                            data[sendajaxParam] = sendajaxValue;
                            var request = $.get(url, data);

                            request.then(function (response) {
                                // the response is ready
                                // hide loader
                                $loader.hide();


                                // empty dropdown
                                $dd.find('option').remove();

                                // create placeholder option
                                var $option = $('<option></option>')
                                    .attr('value', '')
                                    .text('--- ' + (placeholder || 'انتخاب کنید') + ' ---')
                                    .appendTo($dd);

                                // create options
                                $.each(response, function (i, item) {
                                    item.Id = item.Id || item.id;
                                    item.Title = item.Title || item.title;

                                    var $option = $('<option></option>')
                                        .attr('value', item.Id)
                                        .text(item.Title);

                                    // select current value
                                    if (selectedValue == item.Id) {
                                        $option.prop('selected', true);
                                        setRelatedDropdownValue(name, selectedValue);
                                        fillRelatedDropdown(name);
                                    }

                                    $option.appendTo($dd);
                                });

                                // show dropdown
                                $dd.show();
                            });
                        }

                        function hideRelatedDropdowns(parentDropdownName) {
                            // console.log('hideRelatedDropdowns', parentDropdownName);
                            setRelatedDropdownValue(parentDropdownName, '');
                            fillRelatedDropdown(parentDropdownName);

                            // nested
                            var $parent = $('[data-cdd=\'' + parentDropdownName + '\'][data-has-related-dropdown]');
                            var relatedDropdownName = $parent.attr('data-has-related-dropdown');

                            if (relatedDropdownName)
                                hideRelatedDropdowns(relatedDropdownName);
                        }

                        function setRelatedDropdownValue(parentDropdownName, parentValue) {
                            var $parent = $('[data-cdd=\'' + parentDropdownName + '\'][data-has-related-dropdown]');
                            var relatedDropdownName = $parent.attr('data-has-related-dropdown');
                            var $relatedDropdownContainer = $('[data-cdd=\'' + relatedDropdownName + '\']');
                            $relatedDropdownContainer.attr('data-sendajax-value', parentValue);
                        }

                        function fillRelatedDropdown(parentDropdownName) {
                            var $parent = $('[data-cdd=\'' + parentDropdownName + '\'][data-has-related-dropdown]');
                            var relatedDropdownName = $parent.attr('data-has-related-dropdown');
                            fillDropdown(relatedDropdownName);
                        }

                        // get all dropdowns
                        var $dropdowns = $('[data-cdd]');
                        $dropdowns.each(function () {
                            var name = $(this).attr('data-cdd');
                            fillDropdown(name);
                        });

                        // attach onchange event
                        $('body').on('change', '[data-cdd][data-has-related-dropdown]', function () {
                            var $container = $(this);
                            var name = $container.attr('data-cdd');
                            var $dd = $container.find('select');
                            var value = $dd.val();

                            // we should fill the related dropdown
                            setRelatedDropdownValue(name, value);
                            fillRelatedDropdown(name);
                        });
                    });
                </script>
            ";
        }
    }
}
