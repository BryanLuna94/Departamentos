var marca = {
    idFormGrid: "#marcaGridForm",
    idFormEditor: "#marcaEditorForm",
    updateTargetIdGrid: "#marca-wrapper",

    grid: {

        load: function () {

            $("#Filtro_Descripcion").keypress(function (e) {
                if (e.which == 13) {
                    e.preventDefault();
                    baseGrid.find(route.marca, marca.idFormGrid, "Refrescar", marca.updateTargetIdGrid);
                }
            });

            $(".btn-exportar").click(function (e) {
                marca.grid.exportar();
            });

            baseGrid.init(route.marca, marca.idFormGrid, marca.updateTargetIdGrid, marca.editor.init);
        },

        exportar: function () {
            var form = $(marca.idFormGrid);
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
            baseGrid.ejecutar(route.marca, "eliminar", id, marca.idFormGrid, marca.updateTargetIdGrid, undefined, "¿Está seguro que desea eliminar esta marca?");
        }
    },

    editor: {

        init: function (id, per) {

            if (per == "True" || per == undefined)
                visibleGrab = true;
            else
                visibleGrab = false;

            var title = (id > 0) ? "MODIFICAR MARCA" : "AGREGAR MARCA";
            baseEditor.init(route.marca, id, title, dialog.normal, "#Marca_vDescripcion", undefined, undefined, undefined, visibleGrab);
        },

        load: function () {
            var formContent = $(marca.idFormEditor);

            marca.editor.validation(formContent);
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
                    "Marca.vDescripcion": {
                        validators: {
                            notEmpty: {
                                message: 'Este campo es obligatorio'
                            }
                        }
                    },
                    "Marca.vAbreviatura": {
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

                    var id = $(marca.idFormEditor + " #Marca_iCodMarca").val();
                    if (id == "" || id == "0")
                        marca.editor.agregar();
                    else
                        marca.editor.modificar();
                });
        },


        agregar: function () {
            baseGrid.agregar(route.marca, marca.idFormEditor, marca.idFormGrid, marca.updateTargetIdGrid);
        },

        modificar: function () {
            baseGrid.modificar(route.marca, "modificar", marca.idFormEditor, marca.idFormGrid, marca.updateTargetIdGrid);
        }
    },

}