var home = {
    idFormConfig: "#configEditorForm",
    updateTargetIdGrid: "#empresario-wrapper",

    layoutHead: {

        load: function () {

            var options = {
                onSuccessComplete: function (data) {

                    if (data.VistoNotificaciones == false) $("#lnk_not").append('<div class="notify"> <span class="heartbit"></span> <span class="point"></span> </div>');
                    if (data.VistoEventos == false) $("#lnk_eve").append('<div class="notify"> <span class="heartbit"></span> <span class="point"></span> </div>');
                    if (data.VistoPaquetes == false) $("#lnk_paq").append('<div class="notify"> <span class="heartbit"></span> <span class="point"></span> </div>');
                    if (data.VistoPagos == false) $("#lnk_pag").append('<div class="notify"> <span class="heartbit"></span> <span class="point"></span> </div>');

                }
            };

            baseGrid.ejecutar(route.home, "DatosEstaticos", undefined, undefined, undefined, undefined, undefined, options.onSuccessComplete, "");

        },

    },

    layout: {

        ready: function () {
            var formContent = $(home.idFormConfig);
        },

        load: function () {
            var urlActiva = $('.url-menu.active');
            var li = $(urlActiva).closest('li');
            var ul = $(li).closest('ul');
            var liPadre = $(ul).closest('li');
            if (liPadre.length > 0) {
                $(liPadre).find(".waves-effect").addClass("active");
                var url = $(li).find("a").attr("href");
                $("#hdnMnu").val();
                helperFunctions.setSesion("sUrl", url);
                var ulAbuelo = $(liPadre).closest('ul');
                var liAbuelo = $(ulAbuelo).closest('li');
                if (liAbuelo.length > 0) {
                    $(liAbuelo).find(".waves-effect").addClass("active");
                    $(liAbuelo).addClass("active");
                    $(liAbuelo).find(".nav-second-level.collapse").attr("aria-expanded", "true");
                    $(liAbuelo).find(".nav-second-level.collapse").addClass("in");
                }
            } else {
                var urlAnterior = helperFunctions.getSesion("sUrl");
                var link = $('a[href*="' + urlAnterior + '"]');
                var li = $(link).closest('li');
                var ul = $(li).closest('ul');
                var liPadre = $(ul).closest('li');
                $(liPadre).find(".waves-effect").addClass("active");
                $(liPadre).find("ul").addClass("in");
                $(link).addClass("active");
                $(liPadre).addClass("active");
            }

            var urlFotos = $(".img-usu").attr("src");
            var urlCompleta = helperAjax.obtenerUrlAbsoluta(urlFotos);
            $(".img-usu").attr("src", urlCompleta);
        },

    },

    dashboard1: {
        load: function () {

            var options = {
                onSuccessComplete: function (data) {

                    home.dashboard1.cargarDatosGenerales(data);
                    home.dashboard1.construirGraficoMisEstadosPorMes(data);
                    home.dashboard1.construirGraficoEvolucionGastosMes(data);
                    home.dashboard1.construirDeudasPorDepa(data);
                }
            };

            baseGrid.ejecutar(route.home, "Dashboard1", undefined, undefined, undefined, undefined, undefined, options.onSuccessComplete, "");
        },

        cargarDatosGenerales: function (data) {

            var decDeuda;

            decDeuda = parseFloat(data.DeudaActual).toFixed(2);
            $(".page-title").html('Deuda Actual: S/.' + decDeuda);
            $("#pri_txt1").html(data.TextoAlDia);

            if (data.TieneRetraso === true) {
                $("#pri_img1").addClass("mdi mdi-emoticon-sad");
            } else {
                $("#pri_img1").addClass("mdi mdi-emoticon");
            }
        },

        construirGraficoEvolucionGastosMes: function (data) {

            var labels = [];
            //$.each(data.ListaGastosMensual, function (key, value) {
            //    labels.push(value.Campania);
            //});

            var d1 = []; //producido

            $.each(data.ListaGastosMensual, function (key, value) {
                d1.push(value.Monto);
            });

            var chart = new Chartist.Line('#ct-extra', {
                //dlabels: labels,
                series: [d1]
            }, {
                    showArea: false,
                    showPoint: true,
                    height: 100,
                    chartPadding: {
                        left: -20,
                        top: 10,
                    },
                    axisX: {
                        showLabel: true,
                        showGrid: true
                    },
                    axisY: {
                        showLabel: false,
                        showGrid: false
                    },
                    fullWidth: true,
                    plugins: [
                        Chartist.plugins.tooltip()
                    ]
                });

            chart.on('draw', function (data) {
                //label size
                if (data.type === 'label') { data.element._node.childNodes[0].style.fontSize = '10px' }
            });
        },

        construirGraficoMisEstadosPorMes: function (data) {

            var strHtml = '';

            $.each(data.ListaEstadoCuentaMensualResumido, function (key, value) {

                var decSaldo;

                decSaldo = parseFloat(value.Saldo).toFixed(2);

                strHtml += '<div class="stat-item">';
                strHtml += '<h6>' + value.Campania + '</h6> <b>S/.' + decSaldo + '</b>';
                if (value.AlDia === true)
                    strHtml += '<div><span style="font-size:20px" class="mdi mdi-emoticon text-info"></span></div>';
                else
                    strHtml += '<div><span style="font-size:20px" class="mdi mdi-emoticon-sad text-danger"></span></div>';

                strHtml += '</div>';
            });

            $("#div_historial").html(strHtml);

        },

        construirDeudasPorDepa: function (data) {

            var strHtml = '<div class="row">';
            var intCont = 0;

            $.each(data.ListaDepasEstado, function (key, value) {

                if (intCont % 6 == 0) {
                    strHtml += '</div>';
                    strHtml += '<div class="row">';
                }

                var decSaldo;
                var strClaseEmoticon;

                if (value.Debe === true)
                    strClaseEmoticon = "mdi mdi-emoticon-sad text-danger";
                else
                    strClaseEmoticon = "mdi mdi-emoticon text-info";

                decSaldo = parseFloat(value.Saldo).toFixed(2);

                strHtml += '<div class="col-sm-2 col-xs-6">';
                strHtml += '    <div data-item-cuv="30602" aria-hidden="false" tabindex="-1" role="option">';
                strHtml += '       <input type="hidden" class="PosicionEstrategia" value="0" tabindex="0">';
                strHtml += '           <div data-item-tag="body" class="caja-borde" onclick="javascript:OnClickFichaDetalle(event.target);">';
                strHtml += '               <ul class="expense-box">';
                strHtml += '                   <li>';
                strHtml += '                      <span style="font-size:30px" class="' + strClaseEmoticon + '"></span>';
                strHtml += '                      <div>';
                strHtml += '                         <b>S/.' + decSaldo + '</b>';
                strHtml += '                         <h4>' + value.CodigoDepa + '</h4>';
                strHtml += '                     </div>';
                strHtml += '                  </li>';
                strHtml += '              </ul>';
                strHtml += '          </div>';
                strHtml += '   </div>';
                strHtml += '</div>';

                intCont++;
            });

            strHtml += '<div class="row">';
            $("#dep_est").html(strHtml);

        },
    }

}
