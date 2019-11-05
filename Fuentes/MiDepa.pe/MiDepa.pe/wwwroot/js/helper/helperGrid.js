var helperGrid = {    
    getFunction: function getFunction(code, argNames) {
        argNames = argNames || [];
        var fn = window, parts = (code || "").split(".");
        while (fn && parts.length) {
            fn = fn[parts.shift()];
        }
        if (typeof (fn) === "function") {
            return fn;
        }
        argNames.push(code);
        return Function.constructor.apply(null, argNames);
    },
    
    updateCallback: function () {
        $('table[data-swhgajax="true"],span[data-swhgajax="true"]').each(function () {
            var self = $(this);
            var containerId = '#' + self.data('swhgcontainer');
            var callback = helperGrid.getFunction(self.data('swhgcallback'));

            $(containerId).parent().undelegate(containerId + ' a[data-swhglnk="true"]', 'click');

            $(containerId).parent().delegate(containerId + ' a[data-swhglnk="true"]', 'click', function () {
                $(containerId).swhgLoad($(this).attr('href'), containerId, callback);
                return false;
            });
        });
    },
    loadSpecialHead: function (grid, path, id) {
        $("#" + grid + " thead > tr > th> a, #" + grid + " tfoot > tr > td .foot-left > a").attr("href", function () {
            var vUrl = $(this).attr("href");
            var len = vUrl.length;
            var par = vUrl.indexOf("?");
            vUrl = vUrl.substring(par, len);
            if (id != undefined)
                vUrl = path + vUrl + id;
            else
                vUrl = path + vUrl;
            return vUrl;
        });
    },
    
    headerArrow: function (form, idRowFilter) {
        var dir = $(form).find("#id-Filter-sort").val();
        var col = $(form).find("#id-Filter-column").val();
        
        var head = (form).find("tr" + idRowFilter).next();        
        
        $(head).find("th").append(function () {
            var vUrl = $(this).children("a").attr("href");
            if (vUrl != undefined) {
                if (vUrl.indexOf("sort=" + col + "&") != -1) {
                    var ord = null;
                    if (dir == 'Ascending') {
                        ord = "▲";
                    } else if (dir == 'Descending') {
                        ord = "▼";
                    }
                    return ord;
                }
            }            
        });                
    }
};