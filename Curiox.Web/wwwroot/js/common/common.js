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

    let currentUrl = window.location.pathname;
    debugger
    if (currentUrl.includes('Category')) {
        let allCategory = $('.nav-item');
        let activeCategory = '#' + currentUrl.substring(10);
        for (let item of allCategory) {
            if ($(item).find('div.label-item').html().trim() === activeCategory) {
                $(item).addClass('category-active');
            } else {
                $(item).removeClass('category-active');
            }
        }
    }
    
    

});