$(document).ready(() => {



    $('.delete-user-btn').on('click', (e) => {
        const userId = $(e.currentTarget).attr('delete-user-id');
        $('#userId').val(userId);
        $('#confirmModal').modal("show");
    }); //Open delete user confirm modal

    $('.edit-user-btn').on('click', (e) => {
        const userId = $(e.currentTarget).attr('edit-user-id');
        $.ajax({
            url: `/ManageAccount/ShowUpdateAccountModal?Id=${userId}`,
            success: function (modal) {
                ShowModal(modal)
            }
        });
    }) //Open Edit User Modal

    $('.create-user-btn').on('click', () => {
        $.ajax({
            url: `/ManageAccount/ShowCreateAccountModal`,
            success: function (modal) {
                ShowModal(modal)
            }
        });
    }) // Open Create User Modal

    function ShowModal(modal) {
        const modalId = $(modal).attr("id");
        $('body').append(modal);
        $(`#${modalId}`).modal("show");
        $(`#${modalId}`).on('hidden.bs.modal', () => {
            console.log("hideeee")
            location.reload();
        })
    }
})
