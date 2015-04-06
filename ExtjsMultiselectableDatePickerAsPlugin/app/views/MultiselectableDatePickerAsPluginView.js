Ext.define('ExtjsExamples.views.MultiselectableDatePickerAsPluginView', {
    extend: 'Ext.container.Container',
    initComponent: function () {
        var me = this,
            picker = Ext.create('Ext.picker.Date', {
                plugins: [Ext.create('ExtjsExamples.ux.Multiselect')]
            });
        me.callParent(arguments);
        me.add(picker);
    }
});