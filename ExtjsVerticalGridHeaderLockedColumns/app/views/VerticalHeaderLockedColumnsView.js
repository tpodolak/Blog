Ext.define('ExtjsExamples.views.VerticalHeaderLockedColumnsView', {
    extend: 'Ext.container.Container',
    initComponent: function () {

        var me = this;
        me.callParent(arguments);
        me.vGrid = Ext.create('Ext.grid.Panel', {
            store: me.store,
            plugins: [Ext.create('ExtjsExamples.ux.VerticalHeader')],
            columns: [
                {text: 'Id', dataIndex: 'id'},
                {text: 'First name', dataIndex: 'firstname', locked: true},
                {text: 'Last name', dataIndex: 'lastname'}
            ]

        });
        me.add(me.vGrid);
    }
});