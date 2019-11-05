var reportealmacenesvalorizado = {
    idFormGrid: "#reporteAlmacenesValorizadosGridForm",
    idFormEditor: "#reporteprogramaproduccionanualEditorForm",
    updateTargetIdGrid: "#reporteprogramaproduccionanual-wrapper",

    grid: {

        load: function () {

            $("#Filtro_CodigoMarca").change(function (e) {
                var valor = $("#Filtro_CodigoMarca option:selected").text();
                $("#Marca").val(valor);
            });

        },

        visualizar: function () {


            var form = $(reportealmacenesvalorizado.idFormGrid);
            var url = $('input:radio[name=treporte]:checked').val();

            form.attr('action', url);
            form.attr('target', "_blank");
            form.submit();

        }
    },

}