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
                ShowEditUserModal(modal)
            }
        });
    }) //Open edit user modal

    $('.create-user-btn').on('click', () => {
        $.ajax({
            url: `/ManageAccount/ShowCreateAccountModal`,
            success: function (modal) {
                ShowCreateAccountModal(modal)
            }
        });
    })

    function ShowEditUserModal(modal) {
        $('body').append(modal);
        $('#editUserModal').modal("show");
        $('#editUserModal').on('hidden.bs.modal', () => {
            location.reload();
        })
    }

    function ShowCreateAccountModal(modal) {
        $('body').append(modal);
        $('#createAccountModal').modal("show");
        $('#createAccountModal').on('hidden.bs.modal', () => {
            location.reload();
        })
    }
})
