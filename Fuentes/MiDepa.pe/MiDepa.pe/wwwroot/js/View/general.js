var general = {
    idFormClave: "#claveEditorForm",
    updateTargetIdGrid: "#empresario-wrapper",


    clave: {

        init: function () {
            var title = "INGRESE CLAVE PARA CONTINUAR";
            baseEditor.init(route.clave, undefined, title, dialog.mediano, "#Clave", undefined, undefined, "EditorClave", undefined, undefined, undefined, undefined, true);
        },

        load: function () {
            var formContent = $(general.idFormClave);

            general.clave.validation(formContent);
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
                    "Clave": {
                        validators: {
                            notEmpty: {
                                message: 'Este campo es obligatorio'
                            }
                        }
                    },
                }
            })
                .on('success.form.fv', function (e) {
                    e.preventDefault();

                    general.clave.validarClave();
                });
        },

        validarClave: function (formContent) {
            var id = $("#Clave").val();
            var options = {
                onSuccessComplete: function (data) {
                    if (data === "OK") {
                        programacion.grid.asignarTripulacion();
                    } else {
                        mensaje.advertencia("La clave ingresada es incorrecta");
                    }
                }
            };
            baseGrid.ejecutar(route.clave, "ValidarClave", id, undefined, undefined, undefined, undefined, options.onSuccessComplete, "", undefined, undefined, undefined, false);
        }

    },

}
