var reportekardex = {
    idFormGrid: "#reporteKardexGridForm",
    idFormEditor: "#reporteprogramaproduccionanualEditorForm",
    updateTargetIdGrid: "#reporteprogramaproduccionanual-wrapper",

    grid: {

        load: function () {

            $("#Filtro_CodigoMarca").change(function (e) {
                var valor = $("#Filtro_CodigoMarca option:selected").text();
                $("#Marca").val(valor);
            });

            $("#Filtro_CodigoAlmacen").change(function (e) {
                var valor = $("#Filtro_CodigoAlmacen option:selected").text();
                $("#Almacen").val(valor);
            });

            $("#Filtro_IdMes").change(function (e) {
                var valor = $("#Filtro_IdMes option:selected").text();
                $("#Mes").val(valor);
            });

        },

        visualizar: function () {

            var almacen, mes, anio;

            mes = $("#Filtro_IdMes").val();
            anio = $("#Filtro_Anio").val();
            almacen = $("#Filtro_CodigoAlmacen").val();

            if (mes == "0" || mes == "") {
                mensaje.advertencia("Debe elegir un mes");
                return;
            }

            if (anio == "0" || anio == "") {
                mensaje.advertencia("Debe elegir un año");
                return;
            }

            if (almacen == "0" || almacen == "") {
                mensaje.advertencia("Debe elegir un almacén");
                return;
            }

            var form = $(reportekardex.idFormGrid);
            var url = $('input:radio[name=treporte]:checked').val();

            form.attr('action', url);
            form.attr('target', "_blank");
            form.submit();

        }
    },

}