$(document).ready(function () {
    //page Slider Plugin
    $('.js_PageMainSlider').slick({
        rtl: true,
        slidesToShow: 1,
        slidesToScroll: 1,
        autoplay: true,
        autoplaySpeed: 4000,
    });
    $('.js_MiddelSlider').slick({
        rtl: true,
        slidesToShow: 1,
        slidesToScroll: 1,
        autoplay: true,
        autoplaySpeed: 4000,
        dots: true,
    });
    // make header sticky ti the top
    $(".MainHeader").sticky({ topSpacing: 0 });

    // cut string
    function CutString(obj, LineShow) {
        if (obj.length) {
            obj.trunk8({
                fill: ' ...',
                lines: LineShow,
                side: 'right',
                tooltip: true
            });
        }
    }

    CutString($('.CutString1'), 2);
    CutString($('.CutString2'), 3);
    CutString($('.CutString3'), 3);
    CutString($('.CutString4'), 10);

    $(window).resize(function (event) {
        CutString($('.CutString1'), 2);
        CutString($('.CutString3'), 3);
        CutString($('.CutString4'), 10);
    });
});