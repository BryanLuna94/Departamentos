var campania = {
    idFormGrid: "#campaniaGridForm",
    idFormEditor: "#campaniaEditorForm",
    updateTargetIdGrid: "#campania-wrapper",

    grid: {

        load: function () {

            $("#Filtro_Codigo").keypress(function (e) {
                if (e.which === 13) {
                    e.preventDefault();
                    baseGrid.find(route.campania, campania.idFormGrid, "Refrescar", campania.updateTargetIdGrid);
                }
            });

            $("#Filtro_Anio").keypress(function (e) {
                if (e.which === 13) {
                    e.preventDefault();
                    baseGrid.find(route.campania, campania.idFormGrid, "Refrescar", campania.updateTargetIdGrid);
                }
            });

            $(".btn-exportar").click(function (e) {
                campania.grid.exportar();
            });

            baseGrid.init(route.campania, campania.idFormGrid, campania.updateTargetIdGrid, campania.editor.init);
        },

        exportar: function () {
            var form = $(campania.idFormGrid);
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

        ubicaciones: function (id) {
            var data = "Codigocampania=" + id;

            var options = {
                onSuccessComplete: function (data) {
                    window.location = data;
                }
            };
            baseGrid.ejecutar(route.campania, "RedirectUbicaciones", undefined, $(campania.idFormGrid), undefined, data, undefined, options.onSuccessComplete, "");
        },

        eliminar: function (id) {
            baseGrid.ejecutar(route.campania, "eliminar", id, campania.idFormGrid, campania.updateTargetIdGrid, undefined, "¿Está seguro que desea eliminar este almacén?");
        }
    },

    editor: {

        init: function (id, per) {

            if (per === "True" || per === undefined)
                visibleGrab = true;
            else
                visibleGrab = false;

            var title = (id > 0) ? "MODIFICAR CAMPAÑA" : "AGREGAR CAMPAÑA";
            baseEditor.init(route.campania, id, title, dialog.normal, "#Campania_Anio", undefined, undefined, undefined, visibleGrab);
        },

        load: function () {
            var formContent = $(campania.idFormEditor);

            helperFunctions.datepicker(formContent);

            $("#Campania_Anio").change(function (e) {
                campania.editor.obtenerCodigo();
            });            

            $("#Campania_MesId").change(function (e) {
                campania.editor.obtenerCodigo();
            });

            $(".exis-conc").change(function () {
                campania.editor.bloquearMonto(this);
            });

            campania.editor.validation(formContent);
        },

        bloquearMonto: function (input) {
            if (!$(input).is(':checked')) {
                var fila = $(input).closest('tr');
                $(fila).find(".mont-conc").val('0.00');
                $(fila).find(".mont-conc").attr('readonly', 'readonly');
            } else {
                $(input).closest('tr').find(".mont-conc").removeAttr('readonly');
            }
        },

        obtenerCodigo: function () {
            var anio = $("#Campania_Anio").val();
            var mes = $("#Campania_MesId").val();

            if (anio !== "" && mes !== "") {
                var codigo = anio.toString() + helperFunctions.rellenarCerosIzquierda(mes);
                $("#txtCodigo").val(codigo);
            }
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
                    "Campania.Anio": {
                        validators: {
                            notEmpty: {
                                message: 'Este campo es obligatorio'
                            }
                        }
                    },
                    "Campania.MesId": {
                        validators: {
                            notEmpty: {
                                message: 'Este campo es obligatorio'
                            }
                        }
                    },
                    //"Campania.FechaInicio": {
                    //    validators: {
                    //        notEmpty: {
                    //            message: 'Este campo es obligatorio'
                    //        }
                    //    }
                    //},
                    //"Campania.FechaFin": {
                    //    validators: {
                    //        notEmpty: {
                    //            message: 'Este campo es obligatorio'
                    //        }
                    //    }
                    //}
                }
            })
                .on('success.form.fv', function (e) {
                    e.preventDefault();

                    var id = $(campania.idFormEditor + " #Campania_CampaniaId").val();
                    if (id === "" || id === "0")
                        campania.editor.agregar();
                    else
                        campania.editor.modificar();
                });
        },

        agregar: function () {
            baseGrid.agregar(route.campania, campania.idFormEditor, campania.idFormGrid, campania.updateTargetIdGrid);
        },

        modificar: function () {
            baseGrid.modificar(route.campania, "modificar", campania.idFormEditor, campania.idFormGrid, campania.updateTargetIdGrid);
        }
    },

}