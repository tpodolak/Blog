Ext.define('ExtjsExamples.ux.VerticalHeader', {
    alias: 'plugin.verticalheader',
    grid: null,
    textMetric: null,
    init: function (grid) {
        var me = this;
        me.grid = grid;
        me.grid.addCls('v-vertical-header-grid');
        me.textMetric = new Ext.util.TextMetrics();
        me.grid.on({
            afterlayout: {
                scope: me,
                fn: me.handleAfterLayout
            }
        });
    },

    constructor: function (cfg) {
        Ext.apply(this, cfg);
    },

    handleAfterLayout: function (cmp) {
        var me = this,
            maxWidth = 0,
            headerItems = cmp.headerCt.items,
            curremtWidth;

        headerItems.each(function (item) {
            if ((curremtWidth = me.textMetric.getWidth(item.text)) > maxWidth) {
                maxWidth = curremtWidth + 10;
            }
        });

        cmp.headerCt.el.select('.x-column-header-text').each(function (el) {
            el.setSize(maxWidth, maxWidth);
        });
    }
});