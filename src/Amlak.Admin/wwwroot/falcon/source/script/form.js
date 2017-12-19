// version 1.0.0 - 2016/01/26
; (function () {
    if (!window.angular) {
        return;
    }

    var app = window.app = angular.module('app', []);

    app.filter('raw', function ($sce) {
        return function (val) {
            return $sce.trustAsHtml(val);
        };
    });

    app.filter('jalali', function () {
        return function (inputDate, format) {
            // console.log(inputDate);

            if (!inputDate) {
                return '';
            }

            moment.loadPersian();
            var date = moment(inputDate);
            var formattedDate = inputDate;

            try {
                formattedDate = date.format(format);
            } catch (e) {

            }

            return formattedDate;
        }
    });

    app.factory('Form', function () {
        var Form = function (defaultProperties) {
            $.extend(this, defaultProperties);
        };

        Form.prototype.buildFieldsetsHierarchy = function () {
            var thiz = this;

            var values = thiz.Value;
            var fields = thiz.FormTemplate.Fields;
            var fieldsets = thiz.FormTemplate.Fieldsets;

            // [1] extract fields 
            var fieldsMap = (function () {
                var _fields = {};

                // we have multiple groups in our fields
                // like booleans, texts, numbers, checkboxes, radios
                // we loop through them all
                for (var group in fields) {
                    // get current group fields
                    var groupFields = fields[group];

                    // if there is no item
                    // continue to the next one
                    if (!groupFields || !groupFields.length) {
                        continue;
                    }

                    // loop through current group fields
                    groupFields.forEach(function (field) {
                        field._type = group;
                        _fields[field.Id] = field;
                    });
                }

                return _fields;
            }());
            // console.log(fieldsMap);

            // [2] extract values
            var valuesMap = (function() {
                // [1.1] extract values
                var _values = {};

                // we have multiple groups in our values
                // like booleans, texts, numbers, checkboxes, radios
                // we loop through themn all
                for (var group in values) {
                    /// get current group values
                    var groupValues = values[group];

                    // if there is no item
                    // continue to the next one
                    if (!groupValues || !groupValues.length) {
                        continue;
                    }

                    // loop through current group fields
                    groupValues.forEach(function (value) {
                        _values[value.Id] = value;
                    });
                }

                return _values;
            }());
            // console.log(valuesMap);

            // [2] build fieldsets hierarchy
            var fieldsetsHierarchy = (function () {
                // console.log(fieldsets);
                var _fieldsets = [];

                // loop through fieldsets
                if (!fieldsets.length) {
                    return _fieldsets;
                }

                fieldsets.forEach(function (fieldset) {
                    // loop through fields
                    if (!fieldset.FieldIds || !fieldset.FieldIds.length) {
                        return;
                    }

                    var _fields = [];
                    fieldset.FieldIds.forEach(function (fieldId) {
                        // check if field is exists yet or not
                        var realField = fieldsMap[fieldId];

                        // if the field doesn't exists
                        // continue to the next one
                        if (!realField) {
                            return;
                        }

                        if (realField._type == 'Radios') {
                            var itemsMap = {};

                            if (realField.Items.length) {
                                realField.Items.forEach(function(item) {
                                    itemsMap[item.Id] = item.Title;
                                });
                            }

                            // console.log(fieldId, valuesMap[fieldId], itemsMap);
                            realField.Value = itemsMap[valuesMap[fieldId].Value];
                        }
                        else if (realField._type == 'Checkboxes') {
                            var itemsMap = {};

                            if (realField.Items.length) {
                                realField.Items.forEach(function (item) {
                                    itemsMap[item.Id] = item.Title;
                                });
                            }

                            var value = [];
                            if (valuesMap[fieldId].Values.length) {
                                valuesMap[fieldId].Values.forEach(function(v) {
                                    // console.log(v, itemsMap[v]);
                                    value.push(itemsMap[v]);
                                });
                            }

                            realField.Value = value.join('<br>');
                        }
                        else if (realField._type == 'Booleans') {
                            realField.Value = valuesMap[fieldId].Value ? (realField.TrueText || 'بلی') : (realField.FalseText || 'خیر');
                        }
                        else if (realField._type == 'Numbers') {
                            realField.Value = valuesMap[fieldId].Value + ' ' + realField.Unit;
                        } else {
                            realField.Value = valuesMap[fieldId].Value;
                        }

                        _fields.push(realField);
                    });

                    fieldset.fields = _fields;
                    _fieldsets.push(fieldset);
                });

                return _fieldsets;
            }());

            thiz.fieldsetsHierarchy = fieldsetsHierarchy;
        };

        return Form;
    });

    app.controller('FormController', function (Form, $http, $q) {
        var thiz = this;

        thiz.init = function () {
            var url = '/api/office/formtemplate/getall/';

            thiz.FormTemplates = [];
            thiz.FormsPaginated = false;
            thiz.Form = false;

            $http({
                url: url,
                data: {},
                method: 'GET',
                responseType: "json",
                headers: { 'Content-Type': 'application/json; charset=UTF-8' }
            }).then(function (response) {
                thiz.FormTemplates = response.data;
            });
        };

        var loadForms_canceler;
        thiz.loadForms = function (formTemplate) {
            var formTemplateId = formTemplate.Id;

            var url = '/api/office/form/GetPaginated/';
            thiz.CurrentFormTemplateId = formTemplateId;
            thiz.FormsPaginated = false;
            thiz.Form = false;
            thiz.CurrentFormId = false;

            try {
                loadForms_canceler.resolve();
            } catch (e) {
            }

            loadForms_canceler = $q.defer();

            formTemplate.isLoading = true;
            $http({
                url: url,
                params: { formTemplateId: formTemplateId },
                data: {},
                method: 'GET',
                timeout: loadForms_canceler.promise,
                responseType: "json",
                headers: { 'Content-Type': 'application/json; charset=UTF-8' }
            }).then(function (response) {
                thiz.FormsPaginated = response.data;
                formTemplate.isLoading = false;

                // thiz.loadForm(thiz.FormsPaginated.Data[0].Id);
            }, function() {
                formTemplate.isLoading = false;
            });
        };

        var loadForm_canceler;
        thiz.loadForm = function (form) {
            var formId = form.Id;
            form.isLoading = true;

            var url = '/api/office/form/Get/';
            thiz.CurrentFormId = formId;
            thiz.Form = false;

            try {
                loadForm_canceler.resolve();
            } catch (e) {
            }

            loadForm_canceler = $q.defer();

            $http({
                url: url,
                params: { formId: formId },
                data: {},
                method: 'GET',
                timeout: loadForm_canceler.promise,
                responseType: "json",
                headers: { 'Content-Type': 'application/json; charset=UTF-8' }
            }).then(function (response) {
                // console.log(response.data);
                form.isLoading = false;
                thiz.Form = new Form(response.data);
                thiz.Form.buildFieldsetsHierarchy();
                // console.log(thiz.Form.fieldsetsHierarchy);
            }, function() {
                form.isLoading = false;
            });
        };

        thiz.deleteForm = function(formId) {
            var url = '/api/office/form/Delete/';

            $http({
                url: url,
                params: { formId: formId },
                data: {},
                method: 'GET',
                responseType: "json",
                headers: { 'Content-Type': 'application/json; charset=UTF-8' }
            }).then(function (response) {
                console.log(response.data);
            });
        };

        thiz.updateIsArchived = function(formId, isArchived) {
            var url = '/api/office/form/UpdateIsArchived/';

            $http({
                url: url,
                params: { formId: formId, isArchived: isArchived },
                data: {},
                method: 'GET',
                responseType: "json",
                headers: { 'Content-Type': 'application/json; charset=UTF-8' }
            }).then(function (response) {
                console.log(response.data);
            });
        };

    });
}());