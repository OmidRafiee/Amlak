$(function() {
    $('[data-role="confirm"]').on('click',
        function() {
            return confirm('آیا مطمئن هستید؟');
        });
});