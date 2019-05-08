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