var CommonJS = {
    /* -----------------------------------------
     * Show success message
     * Created by: NCThanh
     */
    showSuccessMsg: function (msg) {
        $('body').append('<div class="msg-success alert">' + msg + '</div>');
        $('.msg-success').animate({ top: '0px' });
        setTimeout(function () {
            $('.msg-success').animate({ top: '-52px' });
        }, 3000);

    },

    /* -----------------------------------------
     * Show fail message
     * Created by: NCThanh
     */
    showFailMsg: function (msg) {
        $('body').append('<div class="msg-fail alert">' + msg + '</div>');
        $('.msg-fail').animate({ top: '0px' });
        setTimeout(function () {
            $('.msg-fail').animate({ top: '-52px' });
        }, 3000);
    }    
}

$(document).ready(function () {
    $('.nav-item').on('click', function () {
        let activeCategory = $(this).find('div.label-item').html();
        localStorage.setItem('activeCategory', activeCategory);
    });

    let activeCategory = localStorage.getItem('activeCategory');
    let allCategory = $('.nav-item');
    for (let item of allCategory) {
        if ($(item).find('div.label-item').html() === activeCategory) {
            $(item).addClass('category-active');
        } else {
            $(item).removeClass('category-active');
        }
    }

});