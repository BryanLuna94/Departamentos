var pago = {
    idFormGrid: "#pagoGridForm",
    idFormEditor: "#pagoEditorForm",
    updateTargetIdGrid: "#pago-wrapper",

    grid: {

        load: function () {

            $("#Filtro_Depa").keypress(function (e) {
                if (e.which == 13) {
                    e.preventDefault();
                    baseGrid.find(route.pago, pago.idFormGrid, "Refrescar", pago.updateTargetIdGrid);
                }
            });

            $("#Filtro_FechaPagoIni").keypress(function (e) {
                if (e.which == 13) {
                    e.preventDefault();
                    baseGrid.find(route.pago, pago.idFormGrid, "Refrescar", pago.updateTargetIdGrid);
                }
            });

            $("#Filtro_FechaPagoFin").keypress(function (e) {
                if (e.which == 13) {
                    e.preventDefault();
                    baseGrid.find(route.pago, pago.idFormGrid, "Refrescar", pago.updateTargetIdGrid);
                }
            });

            $("#Filtro_NroVoucher").keypress(function (e) {
                if (e.which == 13) {
                    e.preventDefault();
                    baseGrid.find(route.pago, pago.idFormGrid, "Refrescar", pago.updateTargetIdGrid);
                }
            });

            $("#Filtro_CodigoCampania").change(function (e) {
                baseGrid.find(route.pago, pago.idFormGrid, "Refrescar", pago.updateTargetIdGrid);
            });

            $("#Filtro_EstadoId").change(function (e) {
                baseGrid.find(route.pago, pago.idFormGrid, "Refrescar", pago.updateTargetIdGrid);
            });

            $(".btn-exportar").click(function (e) {
                pago.grid.exportar();
            });

            baseGrid.init(route.pago, pago.idFormGrid, pago.updateTargetIdGrid, undefined);
        },

        exportar: function () {
            var form = $(pago.idFormGrid);
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
        }
    },

    aprobacion: {

        init: function (id) {
            var title = "APROBACION";
            baseEditor.init(route.pago, id, title, dialog.normal, "#pago_vDescripcion", undefined, undefined, "EditorAprobacion", false, false);
        },

        load: function () {
            var formContent = $(pago.idFormEditor);

            $("#btn_aprobar").click(function (e) {
                pago.aprobacion.aprobar();
            });

            $("#btn_rechazar").click(function (e) {
                pago.aprobacion.rechazar();
            });
        },

        aprobar: function () {

            var observacion = $("#Pago_Observacion").val();

            if (observacion === "") {
                mensaje.alerta("Debe ingresar una observación");
                return;
            }

            baseGrid.modificar(route.pago, "aprobar", pago.idFormEditor, pago.idFormGrid, pago.updateTargetIdGrid, true, undefined, "¿Está seguro que desea aprobar este pago?");
        },

        rechazar: function () {

            var observacion = $("#Pago_Observacion").val();



            if (observacion === "") {
                mensaje.alerta("Debe ingresar una observación");
                return;
            }

            baseGrid.modificar(route.pago, "rechazar", pago.idFormEditor, pago.idFormGrid, pago.updateTargetIdGrid, true, undefined, "¿Está seguro que desea rechazar este pago?");
        }
    },

}