Ext.define('ExtjsExamples.views.ValidatableGridView', {
    extend: 'Ext.container.Container',
    initComponent: function () {

        var me = this;
        me.callParent(arguments);
        me.vGrid = Ext.create('Ext.grid.Panel', {
            store: me.store,
            plugins: [Ext.create('ExtjsExamples.ux.ValidatableGrid')],
            columns: [
                {text: 'Id', dataIndex: 'id'},
                {text: 'First name', dataIndex: 'firstname'},
                {text: 'Last name', dataIndex: 'lastname'}
            ]

        });
        me.add(me.vGrid, {
            xtype: 'button',
            text: 'Validate'
        });
    }
});