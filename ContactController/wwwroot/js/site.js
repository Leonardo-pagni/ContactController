$(document).ready(function () {
    $('#table-contacts').DataTable();

    $('.btn-total-contacts').click(function () {
        var userId = $(this).data('user-id');
        console.log(userId);

        $.ajax({
            type: 'GET',
            url: '/User/ListContactsPerUserId?userId=' + userId
            , success: function (result) {
                $("#listContactsUser").html(result);
                var modal = new bootstrap.Modal(document.getElementById('modalContactsUsers'));
                $('#table-modal-contacts').DataTable();
                modal.show();
            }
        });
    });
});
