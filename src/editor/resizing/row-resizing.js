(function(f, define) {
    define(["../main", "../../kendo.resizable", "./resizing-utils"], f);
})(function() {

(function(kendo, undefined) {
    var $ = kendo.jQuery;
    var extend = $.extend;
    var proxy = $.proxy;

    var Editor = kendo.ui.editor;
    var Class = kendo.Class;
    
    var COMMA = ",";
    var MOUSE_MOVE = "mousemove";
    var NS = ".kendoEditorRowResizing";
    var ROW = "tr";
    var TABLE = "table";

    var RowResizing = Class.extend({
        init: function(element, options) {
            var that = this;

            that.options = extend({}, that.options, options);
            that.options.tags = $.isArray(that.options.tags) ? that.options.tags : [that.options.tags];

            if ($(element).is(TABLE)) {
                that.element = element;
                $(element).on(MOUSE_MOVE + NS, that.options.tags.join(COMMA), proxy(that._detectRowBorderHovering, that));
            }
        },

        destroy: function() {
            var that = this;

            $(that.element).off(NS);
            that.element = null;
        },

        options: {
            tags: [ROW],
            rtl: false,
            rootElement: null
        },

        resizingInProgress: function() {
            var that = this;
            var resizable = that.resizable;

            if (resizable) {
                return !!resizable.resizing;
            }

            return false;
        },

        _detectRowBorderHovering: function() {

        }
    });

    extend(Editor, {
        RowResizing: RowResizing
    });

})(window.kendo);

}, typeof define == 'function' && define.amd ? define : function(a1, a2, a3){ (a3 || a2)(); });