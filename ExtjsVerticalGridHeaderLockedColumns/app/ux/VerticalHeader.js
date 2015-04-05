Ext.define('ExtjsExamples.ux.VerticalHeader', {
    alias: 'plugin.verticalheader',
    grid: null,
    extraCfg:null,
    textMetric: null,
    init: function (grid) {
        var me = this;
        me.grid = grid;
        me.grid.addCls('v-vertical-header-grid');
        me.textMetric = new Ext.util.TextMetrics();

        if (me.isLocked()) {
            var normalGridPlugin = Ext.create('ExtjsExamples.ux.VerticalHeader',me.extraCfg),
                lockedGridPlugin = Ext.create('ExtjsExamples.ux.VerticalHeader',me.extraCfg);
            normalGridPlugin.init(me.grid.normalGrid);
            lockedGridPlugin.init(me.grid.lockedGrid);
            me.grid.normalGrid.plugins.push(normalGridPlugin);
            me.grid.lockedGrid.plugins.push(lockedGridPlugin);

        } else {
            me.grid.on({
                afterlayout: {
                    scope: me,
                    fn: me.handleAfterLayout
                }
            });
        }
    },

    constructor: function (cfg) {

        var me = this;
        me.extraCfg = cfg;
        Ext.apply(this, cfg);
        me.callParent(arguments);
    },

    handleAfterLayout: function (cmp) {
        var me = this,
            maxWidth = 0,
            headerItems = cmp.headerCt.items,
            currentWidth;

        headerItems.each(function (item) {
            if ((currentWidth = me.textMetric.getWidth(item.text)) > maxWidth) {
                maxWidth = currentWidth + 10;
            }
        });

        cmp.headerCt.el.select('.x-column-header-text').each(function (el) {
            el.setSize(maxWidth, maxWidth);
        });
    },

    isLocked: function () {
        var me = this;
        return me.grid.normalGrid && me.grid.lockedGrid;
    }

});