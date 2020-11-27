jQuery(function ($) {
    $.datepicker.regional["pt-BR"] = {
        dateFormat: 'dd/mm/yy',
        dayNames: ['Domingo', 'Segunda', 'Terça', 'Quarta', 'Quinta', 'Sexta', 'Sábado', 'Domingo'],
        dayNamesMin: ['D', 'S', 'T', 'Q', 'Q', 'S', 'S', 'D'],
        dayNamesShort: ['Dom', 'Seg', 'Ter', 'Qua', 'Qui', 'Sex', 'Sáb', 'Dom'],
        monthNames: ['Janeiro', 'Fevereiro', 'Março', 'Abril', 'Maio', 'Junho', 'Julho', 'Agosto', 'Setembro', 'Outubro', 'Novembro', 'Dezembro'],
        monthNamesShort: ['Jan', 'Fev', 'Mar', 'Abr', 'Mai', 'Jun', 'Jul', 'Ago', 'Set', 'Out', 'Nov', 'Dez']
    };
});


$(function () {
    var culture = "pt-BR";
    $.datepicker.setDefaults($.datepicker.regional[culture]);
    $("#DateOfBirth").datepicker({
        dateFormat: "dd/mm/yy",
        yearRange: "1930:2030"
    });
});



$(function () {
    if (document.getElementById("Tarefa").value === "") {
        $('#idtexto').html("<h2>CADASTRAR ATIVIDADE</h2>");
        $("#checkStatus").children().prop('disabled', true);
    } else {
        $('#idtexto').html("<h2>EDITAR ATIVIDADE</h2>");
        $("#checkStatus").children().prop('disabled', false);
    }
    return false
});



// Example starter JavaScript for disabling form submissions if there are invalid fields
(function () {
    'use strict';
    window.addEventListener('load', function () {
        // Fetch all the forms we want to apply custom Bootstrap validation styles to
        var forms = document.getElementsByClassName('needs-validation');
        // Loop over them and prevent submission
        var validation = Array.prototype.filter.call(forms, function (form) {
            form.addEventListener('submit', function (event) {
                if (form.checkValidity() === false) {
                    event.preventDefault();
                    event.stopPropagation();
                }
                form.classList.add('was-validated');
            }, false);
        });
    }, false);
})();
