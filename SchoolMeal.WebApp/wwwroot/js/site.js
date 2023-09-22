$(document).ready(() => {
    $('.deleteUserBtn').on('click', (e) => {
        const userId = $(e.currentTarget).attr('data-delete-user-id');
        $('#userId').val(userId);
        $('#confirmModal').modal("show");
    })
})
