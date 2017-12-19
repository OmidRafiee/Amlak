var objectId = (function () {
    /*
    *
    * Copyright (c) 2011-2014- Justin Dearing (zippy1981@gmail.com)
    * Dual licensed under the MIT (http://www.opensource.org/licenses/mit-license.php)
    * and GPL (http://www.opensource.org/licenses/gpl-license.php) version 2 licenses.
    * This software is not distributed under version 3 or later of the GPL.
    *
    * Version 1.0.2
    *
    */

    if (!document) var document = { cookie: '' }; // fix crashes on node

    /**
     * Javascript class that mimics how WCF serializes a object of type MongoDB.Bson.ObjectId
     * and converts between that format and the standard 24 character representation.
    */
    var ObjectId = (function () {
        var increment = Math.floor(Math.random() * (16777216));
        var pid = Math.floor(Math.random() * (65536));
        var machine = Math.floor(Math.random() * (16777216));

        var setMachineCookie = function () {
            var cookieList = document.cookie.split('; ');
            for (var i in cookieList) {
                var cookie = cookieList[i].split('=');
                var cookieMachineId = parseInt(cookie[1], 10);
                if (cookie[0] == 'mongoMachineId' && cookieMachineId && cookieMachineId >= 0 && cookieMachineId <= 16777215) {
                    machine = cookieMachineId;
                    break;
                }
            }
            document.cookie = 'mongoMachineId=' + machine + ';expires=Tue, 19 Jan 2038 05:00:00 GMT;path=/';
        };
        if (typeof (localStorage) != 'undefined') {
            try {
                var mongoMachineId = parseInt(localStorage['mongoMachineId']);
                if (mongoMachineId >= 0 && mongoMachineId <= 16777215) {
                    machine = Math.floor(localStorage['mongoMachineId']);
                }
                // Just always stick the value in.
                localStorage['mongoMachineId'] = machine;
            } catch (e) {
                setMachineCookie();
            }
        }
        else {
            setMachineCookie();
        }

        function ObjId() {
            if (!(this instanceof ObjectId)) {
                return new ObjectId(arguments[0], arguments[1], arguments[2], arguments[3]).toString();
            }

            if (typeof (arguments[0]) == 'object') {
                this.timestamp = arguments[0].timestamp;
                this.machine = arguments[0].machine;
                this.pid = arguments[0].pid;
                this.increment = arguments[0].increment;
            }
            else if (typeof (arguments[0]) == 'string' && arguments[0].length == 24) {
                this.timestamp = Number('0x' + arguments[0].substr(0, 8)),
                this.machine = Number('0x' + arguments[0].substr(8, 6)),
                this.pid = Number('0x' + arguments[0].substr(14, 4)),
                this.increment = Number('0x' + arguments[0].substr(18, 6))
            }
            else if (arguments.length == 4 && arguments[0] != null) {
                this.timestamp = arguments[0];
                this.machine = arguments[1];
                this.pid = arguments[2];
                this.increment = arguments[3];
            }
            else {
                this.timestamp = Math.floor(new Date().valueOf() / 1000);
                this.machine = machine;
                this.pid = pid;
                this.increment = increment++;
                if (increment > 0xffffff) {
                    increment = 0;
                }
            }
        };
        return ObjId;
    })();

    ObjectId.prototype.getDate = function () {
        return new Date(this.timestamp * 1000);
    };

    ObjectId.prototype.toArray = function () {
        var strOid = this.toString();
        var array = [];
        var i;
        for (i = 0; i < 12; i++) {
            array[i] = parseInt(strOid.slice(i * 2, i * 2 + 2), 16);
        }
        return array;
    };

    /**
    * Turns a WCF representation of a BSON ObjectId into a 24 character string representation.
    */
    ObjectId.prototype.toString = function () {
        if (this.timestamp === undefined
            || this.machine === undefined
            || this.pid === undefined
            || this.increment === undefined) {
            return 'Invalid ObjectId';
        }

        var timestamp = this.timestamp.toString(16);
        var machine = this.machine.toString(16);
        var pid = this.pid.toString(16);
        var increment = this.increment.toString(16);
        return '00000000'.substr(0, 8 - timestamp.length) + timestamp +
               '000000'.substr(0, 6 - machine.length) + machine +
               '0000'.substr(0, 4 - pid.length) + pid +
               '000000'.substr(0, 6 - increment.length) + increment;
    };

    return function () {
        var id = new ObjectId();
        return id.toString();
    };

}());

; (function () {
    var template = {
        "Id": ("56a0a55b486ff518e01ce422"),
        "Title": "گروه جدید",
        "Fields": {
            "Texts": [
                {
                    "Id": "569b4af98c68774c516ac31e",
                    "Title": "نام و نام خانوادگی",
                    "DefaultValue": null
                }
            ],
            "Numbers": [
                {
                    "Id": "569b4b018c68774c516ac31f",
                    "Title": "وزن",
                    "Unit": "گرم",
                    "DefaultValue": null,
                    "Range": "10,20,30,40,50"
                }
            ],
            "Booleans": [
                {
                    "Id": "569b4b178c68774c516ac320",
                    "Title": "سه بعدی",
                    "TrueText": "دارد",
                    "FalseText": "ندارد",
                    "DefaultValue": false
                }
            ],
            "Checkboxes": [
                {
                    "Id": "569b4b228c68774c516ac321",
                    "Title": "نوع شبکه ارتباطی",
                    "Items": [
                        {
                            "Id": "569b4b3fc1c44e03fc397cc0",
                            "Title": "2G",
                            "IsChecked": false
                        },
                        {
                            "Id": "569b4b3fc1c44e03fc397cc1",
                            "Title": "3G",
                            "IsChecked": false
                        },
                        {
                            "Id": "569b4b3fc1c44e03fc397cc2",
                            "Title": "4G",
                            "IsChecked": false
                        }
                    ]
                }
            ],
            "Radios": [
                {
                    "Id": "569b4b338c68774c516ac322",
                    "Title": "نوع سیم کارت",
                    "Items": [
                        {
                            "Id": "569b4b3fc1c44e03fc397cc3",
                            "Title": "نانو",
                            "IsChecked": false
                        },
                        {
                            "Id": "569b4b3fc1c44e03fc397cc4",
                            "Title": "میکرو",
                            "IsChecked": false
                        },
                        {
                            "Id": "569b4b3fc1c44e03fc397cc5",
                            "Title": "معمولی",
                            "IsChecked": false
                        }
                    ]
                }
            ]
        },
        "Fieldsets": [
            {
                "Title": "مشخصات کلی",
                "Order": 1,
                "FieldIds": [
                    "569b4af98c68774c516ac31e",
                    "569b4b018c68774c516ac31f",
                    "569b4b338c68774c516ac322"
                ]
            },
            {
                "Title": "مشخصات تخصصی",
                "Order": 2,
                "FieldIds": [
                    "569b4b178c68774c516ac320",
                    "569b4b228c68774c516ac321"
                ]
            }
        ]
    };

    var app = window.app = angular.module('app', ['ng-sortable']);

    app.filter('length', function () {
        return function (object) {
            var length = 0;
            for (var key in object) {
                if (object.hasOwnProperty(key)) {
                    ++length;
                }
            }
            return length;
        };
    });

    app.factory('Category', function () {
        var Category = function (defaultProperties) {
            $.extend(this, defaultProperties);
        };

        Category.prototype.buildFields = function () {
            var thiz = this;

            if (!thiz.Fields) {
                thiz.Fields = {
                    "Texts": [],
                    "Numbers": [],
                    "Booleans": [],
                    "Checkboxes": [],
                    "Radios": []
                };
            }
        };

        Category.prototype.buildFieldsets = function () {
            var thiz = this;

            thiz.FieldsetsHierarchy = _makeFieldsetsHierarchy2(
                thiz.Fieldsets,
                thiz.Fields
            );

            thiz.usedAndRemain = _makeAvailAndUnavailFields(
                thiz.Fields,
                thiz.FieldsetsHierarchy
            );

            thiz.used = _flatObjectToArray(thiz.usedAndRemain.used);
            thiz.remain = _flatObjectToArray(thiz.usedAndRemain.remain);
        };

        var _makeFieldsetsHierarchy2 = function (mfieldsets, mfields) {
            var fields = _makeCategoryFieldsFlat(mfields);

            // make fieldsets
            var fieldsets = function () {
                var f = [];

                if (mfieldsets) {
                    mfieldsets.forEach(function (fieldset) {
                        var _fields = [];

                        if (fieldset.FieldIds) {
                            fieldset.FieldIds.forEach(function (field) {
                                var _field = fields[field];

                                if (_field) {
                                    _fields.push(_field);
                                }
                            });
                        }

                        fieldset.Fields = _fields;

                        var id = objectId();
                        fieldset.Id = id;
                        f.push(fieldset);
                    });
                }

                return f;
            }();

            return fieldsets;
        };

        var _makeCategoryFieldsFlat = function (mfields) {
            // make fields flat
            var fields = function () {
                var f = {};

                if (mfields) {
                    // booleans
                    if (mfields.Booleans) {
                        mfields.Booleans.forEach(function (field) {
                            field._type = 'booleans';
                            f[field.Id] = field;
                        });
                    }

                    // texts
                    if (mfields.Texts) {
                        mfields.Texts.forEach(function (field) {
                            field._type = 'texts';
                            f[field.Id] = field;
                        });
                    }

                    // numbers
                    if (mfields.Numbers) {
                        mfields.Numbers.forEach(function (field) {
                            field._type = 'numbers';
                            f[field.Id] = field;
                        });
                    }

                    // checkboxes
                    if (mfields.Checkboxes) {
                        mfields.Checkboxes.forEach(function (field) {
                            field._type = 'checkboxes';
                            f[field.Id] = field;
                        });
                    }

                    // radios
                    if (mfields.Radios) {
                        mfields.Radios.forEach(function (field) {
                            field._type = 'radios';
                            f[field.Id] = field;
                        });
                    }
                }

                return f;
            }();

            return fields;
        };

        var _flatObjectToArray = function (object) {
            var a = [];

            for (var prop in object) {
                var item = object[prop];
                a.push(item);
            }

            return a;
        };

        var _makeAvailAndUnavailFields = function (allFields, fieldsetsHierarchy) {
            var allFields = _makeCategoryFieldsFlat(allFields);

            var usedFields = {};
            var remainFields = {};

            var fieldsetFields = {};
            fieldsetsHierarchy.forEach(function (fieldset) {
                fieldset.Fields.forEach(function (field) {
                    if (!field) {
                        return true;
                    }

                    usedFields[field.Id] = field;
                });
            });

            for (var prop in allFields) {
                var field = allFields[prop];

                if (!usedFields[field.Id]) {
                    remainFields[field.Id] = field;
                }
            }

            return {
                used: usedFields,
                remain: remainFields
            };
        };

        return Category;
    });

    app.controller('CategoryController', function (Category, $http) {
        var Controller = this;
        var _api = $('html').attr('data-api');

        Controller.Entry = new Category();

        var id = $('#ModelId').val();
        var url = '/api/office/formtemplate/' + id + '/get';

        $http({
            url: url,
            data: {},
            method: 'GET',
            responseType: "json",
            headers: { 'Content-Type': 'application/json; charset=UTF-8' }
        }).then(function (res) {
            var response = res.data;

            Controller.Entry = new Category(response);
            Controller.Entry.buildFields();
            Controller.Entry.buildFieldsets();
        });
        // console.log(Controller.Entry);

        var sendAjaxRequest = function (url, data) {
            $http({
                url: url,
                data: data,
                method: 'POST',
                responseType: "json",
                headers: { 'Content-Type': 'application/json; charset=UTF-8' }
            }).then(function (res) {
                res = res.data;

                swal({
                    title: (res.Succeed ? 'موفق' : 'ناموفق'),
                    text: res.Message || (res.Succeed ? 'تغییرات با موفقیت ذخیره شد' : "خطایی در ارسال درخواست به سرور اتفاق افتاده است"),
                    type: res.Succeed ? "success" : "error",
                    confirmButtonText: "تایید",
                    html: true
                });
            }, function () {
                swal({
                    title: "خطا",
                    text: "خطایی در ارسال درخواست به سرور اتفاق افتاده است",
                    type: "error",
                    confirmButtonText: "تایید",
                    html: true
                });
            });
        };

        Controller.SaveFields = function () {
            var data = { Fields: Controller.Entry.Fields };
            var url = _api + 'office/formtemplate/' + Controller.Entry.Id + '/updatefields';
            sendAjaxRequest(url, data);
        };

        Controller.SaveFieldsets = function () {
            var data = { Fieldsets: Controller.Entry.FieldsetsHierarchy };
            var url = _api + 'office/formtemplate/' + Controller.Entry.Id + '/updatefieldsets';

            // rebuild FieldIds
            if (data.Fieldsets.length) {
                for (var i = 0; i < data.Fieldsets.length; i++) {
                    var fieldset = data.Fieldsets[i];
                    fieldset.FieldIds = [];

                    if (fieldset.Fields) {
                        for (var j = 0; j < fieldset.Fields.length; j++) {
                            fieldset.FieldIds.push(fieldset.Fields[j].Id);
                        }
                    }
                }
            }

            sendAjaxRequest(url, data);
        };

        Controller.Field_addFieldItem = function () {
            var item = {
                'Id': objectId(),
                IsChecked: false,
                Title: ''
            };

            Controller.Field_fieldForEdit.Items = Controller.Field_fieldForEdit.Items || [];
            Controller.Field_fieldForEdit.Items.push(item);
        };

        Controller.Field_deleteFieldItem = function (group, fieldId, itemIndex) {
            var fieldIndex = -1;

            for (var i = 0, l = Controller.Entry.Fields[group].length; i < l; i++) {
                var field = Controller.Entry.Fields[group][i];

                if (field.Id == fieldId) {
                    fieldIndex = i;
                    break;
                }
            }

            if (fieldIndex == -1) {
                return;
            }

            var field = Controller.Entry.Fields[group][fieldIndex];
            field.Items.splice(itemIndex, 1);
        }

        Controller.Field_deleteField = function (group, fieldId) {
            var fieldIndex = -1;

            for (var i = 0, l = Controller.Entry.Fields[group].length; i < l; i++) {
                var field = Controller.Entry.Fields[group][i];

                if (field.Id == fieldId) {
                    fieldIndex = i;
                    break;
                }
            }

            if (fieldIndex > -1) {
                Controller.Entry.Fields[group].splice(fieldIndex, 1);
            }

            Controller.Field_fieldForEdit = false;
        };

        Controller.Field_editField = function (group, fieldId) {
            var field;
            var fieldIndex = -1;

            for (var i = 0, l = Controller.Entry.Fields[group].length; i < l; i++) {
                field = Controller.Entry.Fields[group][i];

                if (field.Id == fieldId) {
                    fieldIndex = i;
                    break;
                }
            }

            if (fieldIndex == -1) {
                return;
            }

            field = Controller.Entry.Fields[group][fieldIndex];
            field._type = group;
            Controller.Field_fieldForEdit = field;
            console.log(field);
        };

        Controller.Field_addField = function (group) {
            var field = {
                _type: group,
                Title: 'فیلد جدید',
                Id: objectId()
            };

            if (group == 'Checkboxes' || group == 'Radios') {
                field.Items = [
                    { 'Id': objectId(), 'Title': '' },
                    { 'Id': objectId(), 'Title': '' },
                    { 'Id': objectId(), 'Title': '' }
                ];
            }

            Controller.Entry.Fields[group].push(field);
            Controller.Field_fieldForEdit = field;
        };

        Controller.Fieldset_addGroup = function () {
            if (!Controller.Fieldset_newGroupTitle) {
                return;
            }

            var id = objectId();

            var fieldset = {
                Id: id,
                Title: Controller.Fieldset_newGroupTitle,
                Fields: []
            };

            Controller.Entry.FieldsetsHierarchy.push(fieldset);

            Controller.Fieldset_newGroupTitle = '';
        };

        Controller.Fieldset_deleteGroup = function (id) {
            var index = -1;

            for (var i = 0, l = Controller.Entry.FieldsetsHierarchy.length; i < l; i++) {
                var fieldset = Controller.Entry.FieldsetsHierarchy[i];

                if (id == fieldset.Id) {
                    index = i;
                    break;
                }
            }

            var fields = Controller.Entry.FieldsetsHierarchy[index].Fields;
            if (fields && fields.length) {
                fields.forEach(function (field) {
                    var fieldId = field.Id;

                    // rearange used and remain fields
                    Controller.Entry.usedAndRemain.remain[fieldId] = Controller.Entry.usedAndRemain.used[fieldId];
                    delete Controller.Entry.usedAndRemain.used[fieldId];
                });
            }

            if (index > -1) {
                Controller.Entry.FieldsetsHierarchy.splice(index, 1);
            }
        }

        Controller.Fieldset_deleteField = function (fieldsetId, fieldId) {
            var fieldsetIndex = -1;
            var fieldIndex = -1;

            for (var i = 0, l = Controller.Entry.FieldsetsHierarchy.length; i < l; i++) {
                var fieldset = Controller.Entry.FieldsetsHierarchy[i];

                if (fieldsetId == fieldset.Id) {
                    fieldsetIndex = i;

                    for (var j = 0, k = fieldset.Fields.length; j < k; j++) {
                        var field = fieldset.Fields[j];

                        if (fieldId == field.Id) {
                            fieldIndex = j;
                            break;
                        }
                    }

                    break;
                }
            }

            if (fieldsetIndex > -1 && fieldIndex > -1) {
                Controller.Entry.FieldsetsHierarchy[fieldsetIndex].Fields.splice(fieldIndex, 1);
            }

            // rearange used and remain fields
            Controller.Entry.usedAndRemain.remain[fieldId] = Controller.Entry.usedAndRemain.used[fieldId];
            delete Controller.Entry.usedAndRemain.used[fieldId];

            // console.log(Controller.Entry.usedAndRemain);

            // Controller.Entry.used = ShopCategoryService.flatObjectToArray(Controller.Entry.usedAndRemain.used);
            // Controller.Entry.remain = ShopCategoryService.flatObjectToArray(Controller.Entry.usedAndRemain.remain);
            // console.log(Controller.Entry.remain);
        }

        Controller.Fieldset_addField = function (fieldsetId, fieldId) {
            // console.log(fieldsetId, fieldId);
            var fieldsetIndex = -1;

            for (var i = 0, l = Controller.Entry.FieldsetsHierarchy.length; i < l; i++) {
                var fieldset = Controller.Entry.FieldsetsHierarchy[i];

                if (fieldsetId == fieldset.Id) {
                    fieldsetIndex = i;
                    break;
                }
            }

            var field = Controller.Entry.usedAndRemain.remain[fieldId];
            Controller.Entry.FieldsetsHierarchy[fieldsetIndex].Fields.push(field);

            // Controller.Entry.FieldsetsHierarchy[fieldsetIndex].FieldIds = Controller.Entry.FieldsetsHierarchy[fieldsetIndex].FieldIds || [];
            // Controller.Entry.FieldsetsHierarchy[fieldsetIndex].FieldIds.push(field.Id);

            // rearange used and remain fields
            Controller.Entry.usedAndRemain.used[fieldId] = Controller.Entry.usedAndRemain.remain[fieldId];
            delete Controller.Entry.usedAndRemain.remain[fieldId];
        };
    });
}());