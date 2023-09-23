$(document).ready(() => {
    $('.delete-user-btn').on('click', (e) => {
        const userId = $(e.currentTarget).attr('delete-user-id');
        $('#userId').val(userId);
        $('#confirmModal').modal("show");
    }); //Open delete user confirm modal

    $('.edit-user-btn').on('click', (e) => {
        //write code here.... //..
    }) //Open edit user modal
})
