$(function () {
    // theme JS
    Main.init();

    // scrollbar
    $('.perfect-scrollbar').mCustomScrollbar({ theme: 'minimal-dark' });

    // select2
    $('.select2').select2({
        theme: "classic",
        dir: "rtl",
        "language": {
            "noResults": function () {
                return "نتیجه‌ای یافت نشد";
            }
        }
    });

    $(document).ready(function () {
        // $('#ribbon').show().ribbon();
    });

    function showBeautyMessage(res) {
        var res = res || {};

        swal({
            title: (res.Succeed ? 'موفق' : 'ناموفق'),
            text: res.Message || (res.Succeed ? 'تغییرات با موفقیت ذخیره شد' : "خطایی در ارسال درخواست به سرور اتفاق افتاده است"),
            type: res.Succeed ? "success" : "error",
            confirmButtonText: "تایید",
            html: true
        });
    }

    $('form.form-ajax').on('submit', function(e) {
        e.preventDefault();
        var $form = $(this);

        $.fn.serializeObject = function () {
            var o = {};
            var a = this.serializeArray();
            $.each(a, function () {
                if (o[this.name] !== undefined) {
                    if (!o[this.name].push) {
                        o[this.name] = [o[this.name]];
                    }
                    o[this.name].push(this.value || '');
                } else {
                    o[this.name] = this.value || '';
                }
            });
            return o;
        };

        var request = $form.serializeObject();
        var $button = $form.find(':submit');

        $button.addClass('loading');

        var url = $form.attr('action');

        $.post(url, request, function (response) {
            $button.removeClass('loading');
            showBeautyMessage(response);
        });
    });
    

    $('[data-role="show-text"]').on('click', function(e) {
        e.preventDefault();
        var text = $(this).attr('data-text');

        swal({
            title: "آدرس فایل",
            text: '<textarea style="width: 90%; font-family: monospace; direction: ltr; resize: none;" readonly>' + text + '</textarea>',
            type: 'info',
            html: true,
            confirmButtonText: "تایید"
        });
    });

    // delete entry confirm
    $('[data-role="delete-entry"]').on('click', function (e) {
        e.preventDefault();
        var url = $(this).attr('data-url') || $(this).attr('href');

        swal({
            title: "آیا مطمئن هستید؟",
            text: "عمل حذف از سیستم، برگشت ناپذیر است و داده‌های مرتبط با این داده، تحت تاثیر قرارخواهند گرفت",
            type: "warning",
            showCancelButton: true,
            confirmButtonColor: "#db2828",
            cancelButtonText: 'انصراف',
            confirmButtonText: "حذف از سیستم",
            closeOnConfirm: false,
            showLoaderOnConfirm: true
        },

        function () {
            window.location = url;
        });
    });

    // active current menu
    (function() {
        var menu = $('html').attr('data-menu');

        if (!menu) {
            return;
        }

        var $menu = $('[data-menu-role="' + menu + '"]');
        $menu.addClass('active open');

        $('.sidebar-container')
            .mCustomScrollbar('scrollTo', $menu, { scrollInertia: 0 })
        ;
    }());

    

    // keyboard shourtcuts
    (function () {
        if (typeof Mousetrap === 'undefined') {
            return false;
        }

        Mousetrap.bind('g d', function (e) {
            var url = $('html').attr('data-dashboard');
            window.location.href = url;
        });

        Mousetrap.bind('d s', function (e) {
            $('form').submit();
        });


    }());

    // ladda
    (function () {
        if (typeof Ladda === 'undefined') {
            return false;
        }

        if (! $.fn.ladda) {
            return false;
        }

        $('a.btn:not([data-role="delete-entry"])')
            .addClass('ladda-button')
            .attr('data-style', 'zoom-out')
            .ladda();


    }());
});

; (function () {
    window.APP = window.APP || {};
    APP.UI = APP.UI || {};

    APP.UI.fancybox = function () {
        if (!$.fn.fancybox) {
            return;
        }

        // loop through all elements
        $('[sam-plugin-fancybox]').each(function () {
            // get current element
            var $elem = $(this);

            // check the previous built flag
            // if the flag is true, there is no need to
            // setup it again
            if ($elem.data('fancybox-init')) {
                return true;
            }

            var autoSize = true;

            var width = $elem.attr('');


            // initialize it
            $elem.fancybox({
                autoSize: false,

                width: '80%',
                height: '80%',

                _beforeLoad: function () {
                    // this.width = parseInt(this.element.data('fancybox-width'));
                    // this.width = 1024;
                    // this.height = parseInt(this.element.data('fancybox-height'));
                },

                helpers: {
                    overlay: {
                        locked: false
                    }
                }
            });

            // mark the element initialization as true
            $elem.data('fancybox-init', true);
        });
    };

    $(function() {
        APP.UI.fancybox();
    });
}());

// check for iframe
function inIframe() {
    try {
        return window.self !== window.top;
    } catch (e) {
        return true;
    }
}
$(function () {
    if (inIframe()) {
        $('html').addClass('sam--insideiframe');
    }
});

var APP = APP || {};
APP.backup = function(module, id, json) {
    var data = "text/json;charset=utf-8," + encodeURIComponent(JSON.stringify(json, null, 4));
    var currentTime = new Date();

    var filename = [
        module + 
        '-',
        id,
        '-',
        currentTime.toJSON().slice(0, 10).replace(/-/g, ''),
        currentTime.toTimeString().slice(0, 8).replace(/:/g, ''),
        '.json'
    ].join('');

    // console.log(filename); return;

    var a = document.createElement('a');
    a.href = 'data:' + data;
    a.download = filename;
    a.innerHTML = 'download JSON';
    a.click();
}

function showBeautyMessage(res) {
    var res = res || {};

    swal({
        title: (res.Succeed ? 'موفق' : 'ناموفق'),
        text: res.Message || (res.Succeed ? 'تغییرات با موفقیت ذخیره شد' : "خطایی در ارسال درخواست به سرور اتفاق افتاده است"),
        type: res.Succeed ? "success" : "error",
        confirmButtonText: "تایید",
        html: true
    });
}

$(function() {
    $('html').addClass('domReady');
});

function postJson(url, data) {
    return $.ajax({
        url: url,
        dataType: "json",
        contentType: "application/json;charset=utf-8",
        type: "POST",
        data: JSON.stringify(data)
    });
}

$(function() {
    $('.ui.dropdown').dropdown();
});

var qs = (function (a) {
    if (a == "") return {};
    var b = {};
    for (var i = 0; i < a.length; ++i) {
        var p = a[i].split('=', 2);
        if (p.length == 1)
            b[p[0]] = "";
        else
            b[p[0]] = decodeURIComponent(p[1].replace(/\+/g, " "));
    }
    return b;
})(window.location.search.substr(1).split('&'));

ObjectId = (function () {
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