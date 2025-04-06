window.sweetAlertHelper = {
    showAlert: function (title, text, icon) {
        Swal.fire({
            title: title,
            text: text,
            icon: icon
        });
    },
    showConfirm: function (title, text, icon) {
        return Swal.fire({
            title: title,
            text: text,
            icon: icon,
            showCancelButton: true,
            confirmButtonText: 'Sí',
            cancelButtonText: 'Cancelar'
        }).then(result => result.isConfirmed);
    }
};
