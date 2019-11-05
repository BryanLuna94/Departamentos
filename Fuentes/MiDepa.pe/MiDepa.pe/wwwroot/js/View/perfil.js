var perfil = {
    idFormGrid: "#perfilGridForm",
    idFormEditor: "#perfilEditorForm",
    idFormEditorOpciones: "#perfilOpcionesEditorForm",
    updateTargetIdGrid: "#perfil-wrapper",

    grid: {

        load: function () {

            $("#Filtro_Nombre").keypress(function (e) {
                if (e.which == 13) {
                    e.preventDefault();
                    baseGrid.find(route.perfil, perfil.idFormGrid, "Refrescar", perfil.updateTargetIdGrid);
                }
            });

            $(".btn-exportar").click(function (e) {
                perfil.grid.exportar();
            });

            baseGrid.init(route.perfil, perfil.idFormGrid, perfil.updateTargetIdGrid, perfil.editor.init);
        },

        exportar: function () {
            var form = $(perfil.idFormGrid);
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
            baseGrid.ejecutar(route.perfil, "eliminar", id, perfil.idFormGrid, perfil.updateTargetIdGrid, undefined, "¿Está seguro que desea eliminar este perfil?");
        }
    },

    editor: {

        init: function (id, per) {

            if (per == "True" || per == undefined)
                visibleGrab = true;
            else
                visibleGrab = false;

            var title = (id > 0) ? "MODIFICAR PERFIL" : "AGREGAR PERFIL";
            baseEditor.init(route.perfil, id, title, dialog.normal, "#Perfil_vNombre", undefined, undefined, undefined, visibleGrab);
        },

        load: function () {
            var formContent = $(perfil.idFormEditor);

            perfil.editor.validation(formContent);
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
                    "Perfil.vNombre": {
                        validators: {
                            notEmpty: {
                                message: 'Este campo es obligatorio'
                            }
                        }
                    }
                }
            })
                .on('success.form.fv', function (e) {
                    e.preventDefault();

                    var id = $(perfil.idFormEditor + " #Perfil_siCodPer").val();
                    if (id == "" || id == "0")
                        perfil.editor.agregar();
                    else
                        perfil.editor.modificar();
                });
        },


        agregar: function () {
            baseGrid.agregar(route.perfil, perfil.idFormEditor, perfil.idFormGrid, perfil.updateTargetIdGrid);
        },

        modificar: function () {
            baseGrid.modificar(route.perfil, "modificar", perfil.idFormEditor, perfil.idFormGrid, perfil.updateTargetIdGrid);
        }
    },

    editorOpciones: {

        init: function (id, per) {

            if (per == "True")
                visibleGrab = true;
            else
                visibleGrab = false;

            baseEditor.init(route.perfil, id, "Opciones por Perfil", dialog.normal, undefined, undefined, undefined, "EditorOpciones", visibleGrab);
        },

        load: function () {

            var formContent = $(perfil.idFormEditorOpciones);

            $(".treeviewJBLV li>ul").css('display', 'none');
            $(".collapsibleJBLV").click(function (e) {
                e.preventDefault();
                $(this).toggleClass("collapseJBLV expandJBLV");
                $(this).closest('li').children('ul').slideToggle();
            });


            $("input[type=checkbox]").click(function (e) {
                var iThisVal = (this.checked ? 1 : 0);
                var sThisId = this.id;
                var sThisFather = this.value;
                var bThisStatus = false;
                $('input[type=checkbox]').each(function () {
                    if (this.value == sThisId) {
                        this.checked = iThisVal;
                        helperFunctions.marcaHijosMenu(iThisVal, this.id)
                    }
                    if (this.value == sThisFather && this.checked)
                        bThisStatus = true;
                });
                helperFunctions.marcaPadresMenu(bThisStatus, sThisFather);
            });

            perfil.editorOpciones.validation(formContent);
        },

        validation: function (formContent) {
            $(formContent).formValidation({
                framework: 'bootstrap',
                icon: {
                    valid: 'glyphicon glyphicon-ok',
                    invalid: 'glyphicon glyphicon-remove',
                    validating: 'glyphicon glyphicon-refresh'
                },
            })
                .on('success.form.fv', function (e) {
                    e.preventDefault();

                    perfil.editorOpciones.agregar();
                });
        },

        agregar: function () {

            var idPerfil = $("#IdPerfil").val()

            var model = {
                "ListaOpciones": [],
                "IdPerfil": idPerfil
            };


            $(perfil.idFormEditorOpciones).find('.treepss2').each(function () {
                var elemento = this;
                var checked = "false";
                var id = this.id;

                if ($(elemento).is(':checked')) {
                    checked = "true";
                }

                model.ListaOpciones.push(
                    {
                        "CodigoOpcion": id,
                        "Existe": checked,
                    });
            });

            baseGrid.modificar(route.perfil, "AgregarOpciones", undefined, undefined, perfil.updateTargetIdGrid, true, model);
        }
    },
}