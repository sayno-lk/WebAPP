//jquery.naviDropDown.1.0.js
(function ($) {
    $.fn.naviDropDown = function (options) {
        var defaults = {
            dropDownClass: 'dropdown',
            dropDownWidth: 'auto',
            slideDownEasing: 'easeInOutCirc',
            slideUpEasing: 'easeInOutCirc',
            slideDownDuration: 500,
            slideUpDuration: 500,
            orientation: 'horizontal'
        };
        var opts = $.extend({}, defaults, options);
        alert(opts);
        return this.each(function () {
         
            var $this = $(this);
            $this.find('.' + opts.dropDownClass).css('width', opts.dropDownWidth).css('display', 'none');
            var buttonWidth = $this.find('.' + opts.dropDownClass).parent().width() + 'px';
            var buttonHeight = $this.find('.' + opts.dropDownClass).parent().height() + 'px';
            if (opts.orientation == 'horizontal') {
                $this.find('.' + opts.dropDownClass).css('top', buttonHeight);
            }
            if (opts.orientation == 'vertical') {
                $this.find('.' + opts.dropDownClass).css('left', buttonWidth).css('top', '0px');
            }
            $this.find('li').hoverIntent(getDropDown, hideDropDown);
        });
        function getDropDown() {
            activeNav = $(this);
            showDropDown();
        }
        function showDropDown() {
            activeNav.find('.' + opts.dropDownClass).slideDown({ duration: opts.slideDownDuration, easing: opts.slideDownEasing });
        }
        function hideDropDown() {
            activeNav.find('.' + opts.dropDownClass).slideUp({ duration: opts.slideUpDuration, easing: opts.slideUpEasing }); //hides the current dropdown
        }
    };
})(jQuery);