Ext.define('ExtjsExamples.views.MultiselectableDatePickerView', {
    extend: 'Ext.container.Container',
    initComponent: function () {
        var me = this,
            picker = Ext.create('ExtjsExamples.ux.HighlightableDatePicker');
        me.callParent(arguments);
        me.add(picker);
    }
});