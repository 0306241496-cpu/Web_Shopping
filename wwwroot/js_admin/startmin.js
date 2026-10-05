$(function () {
    var $sideMenu = $('#side-menu');

    $sideMenu.on('click', 'li > a[data-submenu-toggle]', function (event) {
        event.preventDefault();

        var $link = $(this);
        var $parentLi = $link.parent('li');
        var $submenu = $link.next('ul');

        if (!$submenu.length) {
            return;
        }

        var shouldOpen = !$parentLi.hasClass('active');

        $parentLi.siblings().removeClass('active');
        $parentLi.siblings().children('ul').stop(true, true).slideUp(180);
        $parentLi.siblings().children('a[data-submenu-toggle]').attr('aria-expanded', 'false');

        if (shouldOpen) {
            $parentLi.addClass('active');
            $submenu.stop(true, true).slideDown(180);
            $link.attr('aria-expanded', 'true');
        } else {
            $parentLi.removeClass('active');
            $submenu.stop(true, true).slideUp(180);
            $link.attr('aria-expanded', 'false');
        }
    });

    $sideMenu.find('li > ul').hide();
    $sideMenu.find('li.active > ul').show();
    $sideMenu.find('li.active > a[data-submenu-toggle]').attr('aria-expanded', 'true');
});

//Loads the correct sidebar on window load,
//collapses the sidebar on window resize.
// Sets the min-height of #page-wrapper to window size
$(function() {
    $(window).bind("load resize", function() {
        topOffset = 50;
        width = (this.window.innerWidth > 0) ? this.window.innerWidth : this.screen.width;
        if (width < 768) {
            $('div.navbar-collapse').addClass('collapse');
            topOffset = 100; // 2-row-menu
        } else {
            $('div.navbar-collapse').removeClass('collapse');
        }

        height = ((this.window.innerHeight > 0) ? this.window.innerHeight : this.screen.height) - 1;
        height = height - topOffset;
        if (height < 1) height = 1;
        if (height > topOffset) {
            $("#page-wrapper").css("min-height", (height) + "px");
        }
    });

    var url = window.location;
    var element = $('ul.nav a').filter(function() {
        return this.href == url || url.href.indexOf(this.href) == 0;
    }).addClass('active').parent().parent().addClass('in').parent();
    if (element.is('li')) {
        element.addClass('active');
    }
});
