var general = {

    wizard: {

        init: function () {
            $('.nav-tabs > li a[title]').tooltip();

            //Wizard
            $('a[data-toggle="tab"]').on('show.bs.tab', function (e) {

                var $target = $(e.target);

                if ($target.parent().hasClass('disabled')) {
                    return false;
                }
            });

            $(".next-step").click(function (e) {

                var $active = $('.wizard .nav-tabs li.active');
                $active.next().removeClass('disabled');
                general.wizard.nextTab($active);

            });
            $(".prev-step").click(function (e) {

                var $active = $('.wizard .nav-tabs li.active');
                general.wizard.prevTab($active);

            });
        },

        nextTab: function (elem) {
            $(elem).next().find('a[data-toggle="tab"]').click();
        },

        prevTab: function (elem) {
            $(elem).prev().find('a[data-toggle="tab"]').click();
        },
    },

    treeview: {

        init: function () {
            $(".treeview li>ul").css('display', 'none');
            $(".collapsible").click(function (e) {
                e.preventDefault();
                $(this).toggleClass("collapse expand");
                $(this).closest('li').children('ul').slideToggle();
            });
        }
        
    }
}


