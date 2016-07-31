/// <reference path="../typings/globals/jquery/index.d.ts" />
/// <reference path="../typings/globals/materialize-css/index.d.ts" />

$(document).ready(() => {
    $('#btnJoin').click(function (ev) {
        var id = $(this).data("id");
        $.ajax({
            url: '/Group/JoinGroup/' + id,
            type: 'POST',
            success: function (result) {
                var $toastContent = $('<span>Forespørsel sendt</span>');
                Materialize.toast($toastContent, 10000);
            }
        });
    });
});