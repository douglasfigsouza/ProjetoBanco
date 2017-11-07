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

    $("form").validate({
        submitHandler: function(form) {
            form.submit();
        },
        rules: {
            nome: {
                required: true,
                minlength: 5,
                maxlength: 100
            },
            cpf: {
                required: true
            },
            rg: {
                required: true
            },
            fone: {
                required: true
            },
            bairro: {
                required: true
            },
            rua: {
                required: true
            },
            num: {
                required: true,
            },
            nivel: {
                required: true
            },
            cidadeId: {
                required: true
            },
            senha: {
                required: true,
                minlength: 8,
                maxlength: 8
            },
            senhaCli: {
                required: true,
                minlength: 8,
                maxlength: 8
            },
            conf_senha: {
                required: true,
                equalTo: "#senha",
                maxlength: 8
            },
            agencia: {
                required: true
            },
            conta: {
                required: true
            },
            valor: {
                required: true
            }
        },
        messages: {
            nome: {
                required: "O campo Nome é Obrigatório! Digite-O",
                minlength: "O campo Nome deve conter no mínimo 5 caracteres!",
                maxlength: "O campo Nome deve conter no máximo 100 caracteres!"
            },
            cpf: {
                required: "O campo CPF é Obrigatório! Digite-O"
            },
            rg: {
                required: "O campo RG é Obrigatório! Digite-O"
            },
            fone: {
                required: "O campo Fone é Obrigatório! Digite-O"
            },
            bairro: {
                required: "O campo Bairro é Obrigatório! Digite-O"
            },
            rua: {
                required: "O campo Rua é Obrigatório! Digite-O"
            },
            num: {
                required: "O campo N° é Obrigatório! Digite-O",

            },
            nivel: {
                required: "O campo Nível é Obrigatório! Digite-O"

            },
            cidadeId: {
                required: "Selecione a cidade!"
            },
            senha: {
                required: "O campo senha á obrigatório! Digite-o",
                minlength: "A senha deve conter no minimo 8 caracteres!",
                maxlength: "A senha deve conter no máximo 8 caracteres!"
            },
            senhaCli: {
                required: "O campo senha á obrigatório! Digite-o",
                minlength: "A senha deve conter no minimo 8 caracteres!",
                maxlength: "A senha deve conter no máximo 8 caracteres!"
            },
            conf_senha: {
                required: "O campo Confirme sua Senha é Obrigatório! Digite-O",
                equalTo: "As senhas não conferem"
            },
            agencia: {
                required: "O campo agência é obrigatório! Digite-o."
            },
            conta: {
                required: "O campo conta é obrigatório! Digite-o."
            },
            valor: {
                required: "O Campo valor é obrigatório! Digite-o."
            }
        }
    });
   
});