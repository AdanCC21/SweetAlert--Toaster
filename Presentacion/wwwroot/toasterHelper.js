window.toastrHelper = {
    showSuccess: function (message, title) {
        toastr.success(message, title);
    },
    showError: function (message, title) {
        toastr.error(message, title);
    },
    showInfo: function (message, title) {
        toastr.info(message, title);
    },
    showWarning: function (message, title) {
        toastr.warning(message, title);
    }
};
