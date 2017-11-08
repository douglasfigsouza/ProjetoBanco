$(document).ready(function () {
    $(".agencia").mask("9999-9");
    $(".conta").mask("99.999-9");
    $(".cpf").mask("999.999.999-99");
    $(".rg").mask("99.999.999");
    $(".fone").mask("(99) 9 9999-9999");
    $(".money").maskMoney({
        prefix: "R$ ",
        decimal: ",",
        thousands: "."
    });
});