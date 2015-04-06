Ext.define('ExtjsExamples.views.ExtendedViewPort', {
    extend: 'Ext.container.Viewport',
    layout: 'border',
    defaults: {
        collapsible: false
    },
    items: [{
        id: 'center-container',
        region: 'center',
        xtype: 'panel'

    }],
    initComponent: function () {
        var me = this;
        me.callParent(arguments);
        var ctr = Ext.create('ExtjsExamples.controllers.MasterController', {
            application: me.application
        });
        ctr.launch();
    }
});