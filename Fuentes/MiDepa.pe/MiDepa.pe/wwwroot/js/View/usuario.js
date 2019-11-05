var usuario = {
    idFormGrid: "#usuarioGridForm",
    idFormEditor: "#usuarioEditorForm",
    idFormEditorClave: "#cambiarClaveEditorForm",
    updateTargetIdGrid: "#usuario-wrapper",

    grid: {

        load: function () {

            $("#Filtro_Usuario").keypress(function (e) {
                if (e.which === 13) {
                    e.preventDefault();
                    baseGrid.find(route.usuario, usuario.idFormGrid, "Refrescar", usuario.updateTargetIdGrid);
                }
            });

            $("#Filtro_Perfil").keypress(function (e) {
                if (e.which === 13) {
                    e.preventDefault();
                    baseGrid.find(route.usuario, usuario.idFormGrid, "Refrescar", usuario.updateTargetIdGrid);
                }
            });

            $(".btn-exportar").click(function (e) {
                usuario.grid.exportar();
            });

            baseGrid.init(route.usuario, usuario.idFormGrid, usuario.updateTargetIdGrid, usuario.editor.init);
        },

        exportar: function () {
            var form = $(usuario.idFormGrid);
            var url = $("#hdnURLExportar").val();
            form.attr('action', url);
            form.submit();
        },

        paginarParcial: function () {
            $('#tblLista').DataTable({
                "paging": true,
                "lengthChange": false,
                "searching": false,
                "ordering": true,
                "order": [],
                "info": true,
            });
        },

        eliminar: function (id) {
            baseGrid.ejecutar(route.usuario, "eliminar", id, usuario.idFormGrid, usuario.updateTargetIdGrid, undefined, "¿Está seguro que desea eliminar este usuario?");
        }
    },

    editor: {

        init: function (id, per) {

            if (per == "True" || per == undefined)
                visibleGrab = true;
            else
                visibleGrab = false;

            var title = (id > 0) ? "MODIFICAR USUARIO" : "AGREGAR USUARIO";
            baseEditor.init(route.usuario, id, title, dialog.normal, "#usuario_vNombre", undefined, undefined, undefined, visibleGrab);
        },

        load: function () {
            var formContent = $(usuario.idFormEditor);

            var id = $("#Usuario_siCodUsu").val();
            if (id > 0) {
                $("#divClave").hide();
            } else {

                $("#Usuario_vClave").focus(function () {
                    $("#Usuario_vClave").removeAttr("readonly");
                });
                
            }

            $('.dropify').dropify();

            usuario.editor.obtenerImagen();
            usuario.editor.validation(formContent);
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
                    "Usuario.vNombre": {
                        validators: {
                            notEmpty: {
                                message: 'Este campo es obligatorio'
                            }
                        }
                    },
                    "Usuario.vUsuario": {
                        validators: {
                            notEmpty: {
                                message: 'Este campo es obligatorio'
                            }
                        }
                    },
                    "Usuario.siCodPer": {
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

                    var id = $(usuario.idFormEditor + " #Usuario_siCodUsu").val();
                    if (id == "" || id == "0")
                        usuario.editor.agregar();
                    else
                        usuario.editor.modificar();
                });
        },

        obtenerImagen: function () {
            var ruta = $("#hdnRuta").val();
            $(".dropify-render").find("img").attr("src", ruta);

        },

        agregar: function () {

            var clave = $("#Usuario_vClave").val();

            if (clave === "") {
                mensaje.advertencia("Ingrese la clave de usuario");
                return;
            }

            var formElement = document.getElementById("usuarioEditorForm");
            var data = new FormData(formElement);
            var input = document.getElementById('Archivo');

            data.append('Archivo', input.files[0]);

            var options = {
                route: route.usuario,
                metodo: "Agregar",
                data: data,
                processData: false,
                contentType: false,
                messageSuccess: "Registro Satisfactorio",
                updateTargetId: usuario.updateTargetIdGrid,
                idWrapperEditor: usuario.idFormEditor,
                close: close
            };

            baseGrid.ejecutarAccion(options);
        },

        modificar: function () {

            var formElement = document.getElementById("usuarioEditorForm");
            var data = new FormData(formElement);
            var input = document.getElementById('Archivo');

            data.append('Archivo', input.files[0]);

            var options = {
                route: route.usuario,
                metodo: "Modificar",
                data: data,
                processData: false,
                contentType: false,
                messageSuccess: "Registro Satisfactorio",
                updateTargetId: usuario.updateTargetIdGrid,
                idWrapperEditor: usuario.idFormEditor,
                close: close,
                recargar: true
            };

            baseGrid.ejecutarAccion(options);
        }
    },

    editorPerfil: {

        init: function (id, per) {

            var title = "PERFIL DE USUARIO";
            baseEditor.init(route.usuario, id, title, dialog.normal, "#usuario_vNombre", undefined, undefined, "Perfil", false, undefined, undefined, "Cerrar");
        },

        load: function () {
            $('.dropify').dropify();

            usuario.editor.obtenerImagen();
        },
    },

    editorClave: {

        init: function (id, per) {
            var title = "MODIFICAR CLAVE";
            baseEditor.init(route.usuario, id, title, dialog.normal, "#ClaveAnterior", undefined, undefined, "EditorClave");
        },

        load: function () {
            var formContent = $(usuario.idFormEditorClave);

            usuario.editorClave.validation(formContent);
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
                    "ClaveAnterior": {
                        validators: {
                            notEmpty: {
                                message: 'Este campo es obligatorio'
                            }
                        }
                    },
                    "ClaveNueva": {
                        validators: {
                            identical: {
                                field: 'ClaveConfirma',
                                message: 'Las claves no coinciden'
                            },
                            notEmpty: {
                                message: 'Este campo es obligatorio'
                            }
                        }
                    },
                    "ClaveConfirma": {
                        validators: {
                            identical: {
                                field: 'ClaveNueva',
                                message: 'Las claves no coinciden'
                            },
                            notEmpty: {
                                message: 'Este campo es obligatorio'
                            },
                        }
                    },
                }
            })
                .on('success.form.fv', function (e) {
                    e.preventDefault();

                    usuario.editorClave.modificar();
                });
        },

        modificar: function () {
            baseGrid.ejecutar(route.usuario, "CambiarClave", undefined, undefined, undefined, $(usuario.idFormEditorClave).serialize(), "¿Está seguro que quiere cambiar su clave?", undefined, undefined, true);
        }
    },
}