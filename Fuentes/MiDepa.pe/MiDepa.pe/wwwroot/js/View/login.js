var login = {
    idFormEditor: "#loginForm",
    updateTargetIdGrid: "#login-wrapper",
    editor: {
        load: function () {

            var formContent = $(login.idFormEditor);
            baseEditor.focus(formContent, "#usuario");

            $(document).keypress(function (e) {
                var desabilitado = $('#btnLogOn').attr('disabled');
                if (e.which === 13 && desabilitado !== 'disabled') {
                    $('#btnLogOn').click();
                }
            });

            login.editor.validation(formContent);

            $(formContent).find("#btnLogOn").click(function () {
                var formContentLogin = $(login.idFormEditor);
                var validator = $(formContentLogin).data('formValidation');

                validator.validate();
                if (validator.isValid()) {
                    login.editor.loguearse();
                }
            });
        },

        validation: function (formContent) {
            $(formContent).formValidation({
                framework: 'bootstrap',
                icon: {
                    valid: 'glyphicon glyphicon-ok',
                    invalid: 'glyphicon glyphicon-remove',
                    validating: 'glyphicon glyphicon-refresh'
                },
                fields: {
                    'Usuario': {
                        validators: {
                            notEmpty: {
                                message: 'Ingrese su usuario'
                            }
                        }
                    },

                    'Clave': {
                        validators: {
                            notEmpty: {
                                message: 'Ingrese su contraseña'
                            }
                        }
                    }
                }
            });
        },

        loguearse: function () {
            var options = {
                onSuccessComplete: function (data) {
                    window.location = data;
                }
            };
            baseGrid.ejecutar(route.login, "Login", undefined, login.idFormEditor, undefined, $(login.idFormEditor).serialize(), undefined, options.onSuccessComplete, "Acceso Autorizado");
        }
    }

}