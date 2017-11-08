function progresso() {
    $(".loading").show();
}
function fim() {
    $(".loading").hide();
}
$(document).ready(function () {
    $(".button-collapse").sideNav();
    $('select').material_select();
    $(".divErroNaOperacao").hide();
    $(".divSucessoNaOperacao").hide();
    $(".loading").hide();
    $(".button-collapse").sideNav();
    //verifica checked
    $(document).on("change",
        "#ativo",
        function () {
            debugger;
            if ($("#ativo").is(':checked')) {
                $("#ativo").val(true);
            } else {
                $("#ativo").val(false);
            }
        });
});