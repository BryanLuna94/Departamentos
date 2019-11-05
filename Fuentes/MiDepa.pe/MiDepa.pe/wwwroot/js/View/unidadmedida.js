var unidadmedida = {
    idFormGrid: "#unidadMedidaGridForm",
    idFormEditor: "#unidadMedidaEditorForm",
    updateTargetIdGrid: "#unidadMedida-wrapper",

    grid: {

        load: function () {

            $("#Filtro_Descripcion").keypress(function (e) {
                if (e.which == 13) {
                    e.preventDefault();
                    baseGrid.find(route.unidadmedida, unidadmedida.idFormGrid, "Refrescar", unidadmedida.updateTargetIdGrid);
                }
            });

            $(".btn-exportar").click(function (e) {
                unidadmedida.grid.exportar();
            });

            baseGrid.init(route.unidadmedida, unidadmedida.idFormGrid, unidadmedida.updateTargetIdGrid, unidadmedida.editor.init);
        },

        exportar: function () {
            var form = $(unidadmedida.idFormGrid);
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
            baseGrid.ejecutar(route.unidadmedida, "eliminar", id, unidadmedida.idFormGrid, unidadmedida.updateTargetIdGrid, undefined, "¿Está seguro que desea eliminar esta unidad de medida?");
        }
    },

    editor: {

        init: function (id, per) {

            if (per == "True" || per == undefined)
                visibleGrab = true;
            else
                visibleGrab = false;

            var title = (id > 0) ? "MODIFICAR UNIDAD DE MEDIDA" : "AGREGAR UNIDAD DE MEDIDA";
            baseEditor.init(route.unidadmedida, id, title, dialog.normal, "#UnidadMedida_vDescripcion", undefined, undefined, undefined, visibleGrab);
        },

        load: function () {
            var formContent = $(unidadmedida.idFormEditor);

            unidadmedida.editor.validation(formContent);
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
                    "UnidadMedida.vDescripcion": {
                        validators: {
                            notEmpty: {
                                message: 'Este campo es obligatorio'
                            }
                        }
                    },
                    "UnidadMedida.vAbreviatura": {
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

                    var id = $(unidadmedida.idFormEditor + " #UnidadMedida_siCodUMed").val();
                    if (id == "" || id == "0")
                        unidadmedida.editor.agregar();
                    else
                        unidadmedida.editor.modificar();
                });
        },


        agregar: function () {
            baseGrid.agregar(route.unidadmedida, unidadmedida.idFormEditor, unidadmedida.idFormGrid, unidadmedida.updateTargetIdGrid);
        },

        modificar: function () {
            baseGrid.modificar(route.unidadmedida, "modificar", unidadmedida.idFormEditor, unidadmedida.idFormGrid, unidadmedida.updateTargetIdGrid);
        }
    },

}