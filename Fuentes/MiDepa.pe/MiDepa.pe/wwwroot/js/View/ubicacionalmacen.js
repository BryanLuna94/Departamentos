var ubicacionalmacen = {
    idFormGrid: "#ubicacionAlmacenGridForm",
    idFormEditor: "#ubicacionAlmacenEditorForm",
    updateTargetIdGrid: "#ubicacionAlmacen-wrapper",

    grid: {

        load: function () {

            $("#Filtro_Piso").keypress(function (e) {
                if (e.which == 13) {
                    e.preventDefault();
                    baseGrid.find(route.almacen, ubicacionalmacen.idFormGrid, "RefrescarUbicacion", ubicacionalmacen.updateTargetIdGrid);
                }
            });

            $("#Filtro_Rack").keypress(function (e) {
                if (e.which == 13) {
                    e.preventDefault();
                    baseGrid.find(route.almacen, ubicacionalmacen.idFormGrid, "RefrescarUbicacion", ubicacionalmacen.updateTargetIdGrid);
                }
            });

            $("#Filtro_Fila").keypress(function (e) {
                if (e.which == 13) {
                    e.preventDefault();
                    baseGrid.find(route.almacen, ubicacionalmacen.idFormGrid, "RefrescarUbicacion", ubicacionalmacen.updateTargetIdGrid);
                }
            });

            $("#Filtro_Columna").keypress(function (e) {
                if (e.which == 13) {
                    e.preventDefault();
                    baseGrid.find(route.almacen, ubicacionalmacen.idFormGrid, "RefrescarUbicacion", ubicacionalmacen.updateTargetIdGrid);
                }
            });

            $(".btn-exportar").click(function (e) {
                ubicacionalmacen.grid.exportar();
            });

            baseGrid.init(route.almacen, ubicacionalmacen.idFormGrid, ubicacionalmacen.updateTargetIdGrid, ubicacionalmacen.editor.init);
        },

        exportar: function () {
            var form = $(ubicacionalmacen.idFormGrid);
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
            baseGrid.ejecutar(route.almacen, "EliminarUbicacion", id, ubicacionalmacen.idFormGrid, ubicacionalmacen.updateTargetIdGrid, undefined, "¿Está seguro que desea eliminar esta ubicación?");
        }
    },

    editor: {

        init: function (id, per) {

            if (per == "True" || per == undefined)
                visibleGrab = true;
            else
                visibleGrab = false;

            var title = (id > 0) ? "MODIFICAR UBICACIÓN" : "AGREGAR UBICACIÓN";
            baseEditor.init(route.almacen, id, title, dialog.normal, "#Ubicacion_vPiso", undefined, undefined, "EditorUbicacion", visibleGrab);
        },

        load: function () {
            var formContent = $(ubicacionalmacen.idFormEditor);

            var codAlm = $(ubicacionalmacen.idFormGrid).find("#Filtro_CodigoAlmacen").val();
            $(formContent).find("#Ubicacion_siCodAlm").val(codAlm);

            helperFunctions.formatoNumero(".input-align-right");

            ubicacionalmacen.editor.validation(formContent);
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
                    "Ubicacion.vPiso": {
                        validators: {
                            notEmpty: {
                                message: 'Este campo es obligatorio'
                            }
                        }
                    },
                    "Ubicacion.vRack": {
                        validators: {
                            notEmpty: {
                                message: 'Este campo es obligatorio'
                            }
                        }
                    },
                    "Ubicacion.vFila": {
                        validators: {
                            notEmpty: {
                                message: 'Este campo es obligatorio'
                            }
                        }
                    },
                    "Ubicacion.vColumna": {
                        validators: {
                            notEmpty: {
                                message: 'Este campo es obligatorio'
                            }
                        }
                    },
                    "Ubicacion.dVolumen": {
                        validators: {
                            notEmpty: {
                                message: 'Este campo es obligatorio'
                            }
                        }
                    },
                    "Ubicacion.siCodUMed": {
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

                    var id = $(ubicacionalmacen.idFormEditor + " #Ubicacion_iCodUbi").val();
                    if (id == "" || id == "0")
                        ubicacionalmacen.editor.agregar();
                    else
                        ubicacionalmacen.editor.modificar();
                });
        },


        agregar: function () {
            baseGrid.modificar(route.almacen, "agregarubicacion", ubicacionalmacen.idFormEditor, ubicacionalmacen.idFormGrid, ubicacionalmacen.updateTargetIdGrid);
        },

        modificar: function () {
            baseGrid.modificar(route.almacen, "modificarubicacion", ubicacionalmacen.idFormEditor, ubicacionalmacen.idFormGrid, ubicacionalmacen.updateTargetIdGrid);
        }
    },

}